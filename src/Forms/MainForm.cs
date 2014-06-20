#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CursorLock.src;

#endregion

namespace CursorLock
{
    public partial class MainForm : Form
    {
        private const int WM_HOTKEY     = 0x0312;

        private Thread t_lock;              // Thread for lock loop
        private bool isLocked = false;      // Lock sentinel value
        private Screen selScreen;           // Current screen selected
        private Lock mLock;                 // Controls the cursor position
        private ErrorLogManager eLog;       // Error Log Manager
        private bool isLockable = true;     // Controls wether the program can lock
        private bool isKeyRegister = false; // Tells wether there is a hotkey registered

        public MainForm(ErrorLogManager eLogManager)
        {
            InitializeComponent();

            // Initialize error log
            this.eLog = eLogManager;

            // Add keys to combo box
            AddKeys();

            // Update key values
            UpdateKeyValues();

            // Add monitors to combo box
            AddMonitors();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_HOTKEY)
            {
                Keys vk = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                int fsModifiers = ((int)m.LParam & 0xFFFF);

                if (isLocked)
                {
                    if (vk == Hotkey.GetHotkeyValue() && fsModifiers == Hotkey.GetModkeyValue())
                        StopLock();
                }
                else if (isLockable)
                {
                    if (vk == Hotkey.GetHotkeyValue() && fsModifiers == Hotkey.GetModkeyValue())
                        StartLock();
                }
            }
        }

        #region Custom Methods

        /// <summary>
        /// Populates combo box with available monitors.
        /// </summary>
        private void AddMonitors()
        {
            int sWidth, sHeight;    // Current height and width

            for (int i = 0; i < Screen.AllScreens.Count(); i++)
            {
                // Get current width and height
                sWidth = Screen.AllScreens[i].Bounds.Width;
                sHeight = Screen.AllScreens[i].Bounds.Height;

                // Show user information about each monitor
                monitorComboBox.Items.Add(
                    "Monitor [" + i.ToString() + "]: (" +
                    sWidth.ToString() + ", " + sHeight.ToString() + ")");
            }
        }

        /// <summary>
        /// Adds keys to Combobox 3
        /// </summary>
        private void AddKeys()
        {
            for (int i = 65; i < 91; i++)
            {
                keyComboBox.Items.Add((char)i);
            }
        }

        /// <summary>
        /// Starts cursor lock.
        /// </summary>
        private void StartLock()
        {
            // Starting Lock
            eLog.WriteMsg("Starting Lock");

            // Disable selectors
            monitorComboBox.Enabled = false;
            changeButton.Enabled = false;

            // Set locked
            isLocked = true;

            // Set selected screen
            selScreen = Screen.AllScreens[monitorComboBox.SelectedIndex];

            // Move the screen to where the cursor is locked
            MoveToScreen();

            mLock = new Lock(selScreen);

            // Instantiate and start new thread
            t_lock = new Thread(mLock.LockMouse);
            t_lock.Start();

            // Lock Started
            eLog.WriteMsg("Lock Started");
        }

        /// <summary>
        /// Stops the cursor lock loop, and kills the thread.
        /// </summary>
        private void StopLock()
        {
            eLog.WriteMsg("Stopping Lock");

            // Disable lock
            isLocked = false;

            try
            {
                // Check if lock is still alive
                while (t_lock.IsAlive)
                {
                    // Attempt to join thread
                    t_lock.Join();
                }
            }
            catch (Exception e)
            {
                // Error message
                eLog.WriteError("Lock could not be destroyed!");
                eLog.WriteError(e.Message.ToString());
            }
            finally
            {
                //  Aborts the thread

                mLock.UnlockMouse();

                t_lock.Abort();
            }

            // Enable selectors
            monitorComboBox.Enabled = true;
            changeButton.Enabled = true;
            eLog.WriteMsg("Lock Stopped");
        }

        /// <summary>
        /// Moves the window to the screen that the cursor is
        /// currently locked to.
        /// </summary>
        private void MoveToScreen()
        {
            this.Location = new Point(
                (selScreen.WorkingArea.X + selScreen.WorkingArea.Width / 2) - (this.Width / 2),
                (selScreen.WorkingArea.Y + selScreen.WorkingArea.Height / 2) - (this.Height / 2));
        }

        /// <summary>
        /// Updates hotkey combo boxes
        /// </summary>
        private void UpdateKeyValues()
        {
            int keyVal = Properties.Settings.Default.Setting_key - 65;
            int modVal = Properties.Settings.Default.Setting_modifier_key;

            switch (modVal)
            {
                case Hotkey.MOD_ALT:
                    modKeyComboBox.SelectedIndex = 0;
                    break;

                case Hotkey.MOD_CONTROL:
                    modKeyComboBox.SelectedIndex = 1;
                    break;

                case Hotkey.MOD_SHIFT:
                    modKeyComboBox.SelectedIndex = 2;
                    break;
            }

            keyComboBox.SelectedIndex = keyVal;
            Console.WriteLine("UpdateKeyValues: " + keyVal.ToString());

            if (isKeyRegister)
            {
                UnregisterHotKey(Handle, 42);
                eLog.WriteMsg("UHK_UKF");
                isKeyRegister = false;
            }

            RegisterHotKey(Handle, 42, Hotkey.GetModkeyValue(), (int)Hotkey.GetHotkeyValue());
            isKeyRegister = true;

            eLog.WriteMsg("RHK_UKV -- " + "0x" +
                Hotkey.GetModkeyValue().ToString("X4") +
                ", " + "0x" +
                ((int)Hotkey.GetHotkeyValue()).ToString("X4"));
        }

        #endregion

        #region Generated Methods

        private void mainForm_Load(object sender, EventArgs e)
        {
            monitorComboBox.SelectedIndex = 0;
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop lock
            if (isLocked)
                StopLock();

            // Unregister hot key
            UnregisterHotKey(Handle, 42);

            eLog.WriteMsg("UHK_FC");

            // Program ended
            eLog.WriteMsg("Error Log Deconstructed");
            eLog.WriteCloser();

        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            About mAbout = new About();
            mAbout.Show();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            if (modKeyComboBox.Enabled && keyComboBox.Enabled)
            {
                modKeyComboBox.Enabled = false;
                keyComboBox.Enabled = false;

                // Save keys
                int keyVal = keyComboBox.SelectedIndex + 65;
                int modVal = 0;

                switch (modKeyComboBox.SelectedIndex)
                {
                    case 0:
                        modVal = Hotkey.MOD_ALT;
                        break;

                    case 1:
                        modVal = Hotkey.MOD_CONTROL;
                        break;

                    case 2:
                        modVal = Hotkey.MOD_SHIFT;
                        break;
                }

                Hotkey.SetHotkey(new KeyBind(modVal, keyVal));

                // Update combo boxes with new key values
                UpdateKeyValues();

                changeButton.Text = "Change";
                isLockable = true;
            }
            else if (!isLocked)
            {
                modKeyComboBox.Enabled = true;
                keyComboBox.Enabled = true;

                changeButton.Text = "Save";
                isLockable = false;
            }
        }

        #endregion

        [DllImport("user32")]
        public static extern int RegisterHotKey(IntPtr hwnd, int id, int fsModifiers, int vk);

        [DllImport("user32")]
        public static extern int UnregisterHotKey(IntPtr hwnd, int id);
    }
}

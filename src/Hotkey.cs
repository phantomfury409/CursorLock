#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

namespace CursorLock.src
{
    public class Hotkey
    {
        public const int MOD_ALT     = 0x1;
        public const int MOD_CONTROL = 0x2;
        public const int MOD_SHIFT   = 0x4;

        public Hotkey()
        {

        }

        public static void SetHotkey(KeyBind keyBind)
        {
            Properties.Settings.Default.Setting_modifier_key = keyBind.Modifier;
            Properties.Settings.Default.Setting_key = keyBind.Key;

            Properties.Settings.Default.Save();
        }

        public static Keys GetHotkeyValue()
        {
            return (Keys)Properties.Settings.Default.Setting_key;
        }

        public static int GetModkeyValue()
        {
            return Properties.Settings.Default.Setting_modifier_key;
        }
    }

    public struct KeyBind
    {
        public int Modifier;
        public int Key;

        public KeyBind(int mod, int key)
        {
            this.Modifier = mod;
            this.Key = key;
        }
    }
}
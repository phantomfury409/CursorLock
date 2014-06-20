namespace CursorLock
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.monitorComboBox = new System.Windows.Forms.ComboBox();
            this.aboutButton = new System.Windows.Forms.Button();
            this.changeButton = new System.Windows.Forms.Button();
            this.labelStartStop = new System.Windows.Forms.Label();
            this.monitorGroupBox = new System.Windows.Forms.GroupBox();
            this.hotkeyGroupBox = new System.Windows.Forms.GroupBox();
            this.keyComboBox = new System.Windows.Forms.ComboBox();
            this.modKeyComboBox = new System.Windows.Forms.ComboBox();
            this.monitorGroupBox.SuspendLayout();
            this.hotkeyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // monitorComboBox
            // 
            this.monitorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.monitorComboBox.FormattingEnabled = true;
            this.monitorComboBox.Location = new System.Drawing.Point(11, 19);
            this.monitorComboBox.Name = "monitorComboBox";
            this.monitorComboBox.Size = new System.Drawing.Size(280, 21);
            this.monitorComboBox.TabIndex = 1;
            // 
            // aboutButton
            // 
            this.aboutButton.Location = new System.Drawing.Point(12, 168);
            this.aboutButton.Name = "aboutButton";
            this.aboutButton.Size = new System.Drawing.Size(75, 23);
            this.aboutButton.TabIndex = 6;
            this.aboutButton.Text = "About";
            this.aboutButton.UseVisualStyleBackColor = true;
            this.aboutButton.Click += new System.EventHandler(this.aboutButton_Click);
            // 
            // changeButton
            // 
            this.changeButton.Location = new System.Drawing.Point(218, 24);
            this.changeButton.Name = "changeButton";
            this.changeButton.Size = new System.Drawing.Size(75, 23);
            this.changeButton.TabIndex = 8;
            this.changeButton.Text = "Change";
            this.changeButton.UseVisualStyleBackColor = true;
            this.changeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // labelStartStop
            // 
            this.labelStartStop.AutoSize = true;
            this.labelStartStop.Location = new System.Drawing.Point(10, 28);
            this.labelStartStop.Name = "labelStartStop";
            this.labelStartStop.Size = new System.Drawing.Size(62, 13);
            this.labelStartStop.TabIndex = 13;
            this.labelStartStop.Text = "Start / Stop";
            // 
            // monitorGroupBox
            // 
            this.monitorGroupBox.Controls.Add(this.monitorComboBox);
            this.monitorGroupBox.Location = new System.Drawing.Point(13, 20);
            this.monitorGroupBox.Name = "monitorGroupBox";
            this.monitorGroupBox.Size = new System.Drawing.Size(302, 59);
            this.monitorGroupBox.TabIndex = 15;
            this.monitorGroupBox.TabStop = false;
            this.monitorGroupBox.Text = "Monitor";
            // 
            // hotkeyGroupBox
            // 
            this.hotkeyGroupBox.Controls.Add(this.keyComboBox);
            this.hotkeyGroupBox.Controls.Add(this.modKeyComboBox);
            this.hotkeyGroupBox.Controls.Add(this.labelStartStop);
            this.hotkeyGroupBox.Controls.Add(this.changeButton);
            this.hotkeyGroupBox.Location = new System.Drawing.Point(13, 85);
            this.hotkeyGroupBox.Name = "hotkeyGroupBox";
            this.hotkeyGroupBox.Size = new System.Drawing.Size(302, 69);
            this.hotkeyGroupBox.TabIndex = 17;
            this.hotkeyGroupBox.TabStop = false;
            this.hotkeyGroupBox.Text = "Hotkeys";
            // 
            // keyComboBox
            // 
            this.keyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyComboBox.Enabled = false;
            this.keyComboBox.FormattingEnabled = true;
            this.keyComboBox.Location = new System.Drawing.Point(149, 25);
            this.keyComboBox.Name = "keyComboBox";
            this.keyComboBox.Size = new System.Drawing.Size(63, 21);
            this.keyComboBox.TabIndex = 15;
            // 
            // modKeyComboBox
            // 
            this.modKeyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modKeyComboBox.Enabled = false;
            this.modKeyComboBox.FormattingEnabled = true;
            this.modKeyComboBox.Items.AddRange(new object[] {
            "ALT",
            "CTRL",
            "SHIFT"});
            this.modKeyComboBox.Location = new System.Drawing.Point(78, 25);
            this.modKeyComboBox.Name = "modKeyComboBox";
            this.modKeyComboBox.Size = new System.Drawing.Size(63, 21);
            this.modKeyComboBox.TabIndex = 14;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 203);
            this.Controls.Add(this.hotkeyGroupBox);
            this.Controls.Add(this.monitorGroupBox);
            this.Controls.Add(this.aboutButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cursor Lock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.monitorGroupBox.ResumeLayout(false);
            this.hotkeyGroupBox.ResumeLayout(false);
            this.hotkeyGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox monitorComboBox;
        private System.Windows.Forms.Button aboutButton;
        private System.Windows.Forms.Button changeButton;
        private System.Windows.Forms.Label labelStartStop;
        private System.Windows.Forms.GroupBox monitorGroupBox;
        private System.Windows.Forms.GroupBox hotkeyGroupBox;
        private System.Windows.Forms.ComboBox keyComboBox;
        private System.Windows.Forms.ComboBox modKeyComboBox;
    }
}


namespace Encryptify
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            groupBox1 = new GroupBox();
            listBox_logs = new ListBox();
            groupBox2 = new GroupBox();
            btn_remove = new Button();
            btn_addFile = new Button();
            listBoxPaths = new ListBox();
            groupBox3 = new GroupBox();
            textBox_password = new TextBox();
            button_decrypt = new Button();
            button_Encrypt = new Button();
            button_showpass = new Button();
            groupBox4 = new GroupBox();
            label1 = new Label();
            comboBox_getAlgorithm = new ComboBox();
            checkBox_deleteOriginalfile = new CheckBox();
            groupBox5 = new GroupBox();
            btn_createzip = new Button();
            btn_examine = new Button();
            textBox_Examine = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(listBox_logs);
            groupBox1.Location = new Point(401, 192);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(372, 174);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Logs";
            // 
            // listBox_logs
            // 
            listBox_logs.FormattingEnabled = true;
            listBox_logs.ItemHeight = 15;
            listBox_logs.Location = new Point(6, 14);
            listBox_logs.Name = "listBox_logs";
            listBox_logs.Size = new Size(361, 154);
            listBox_logs.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btn_remove);
            groupBox2.Controls.Add(btn_addFile);
            groupBox2.Controls.Add(listBoxPaths);
            groupBox2.Location = new Point(402, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(372, 174);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Paths";
            // 
            // btn_remove
            // 
            btn_remove.Location = new Point(191, 137);
            btn_remove.Name = "btn_remove";
            btn_remove.Size = new Size(130, 31);
            btn_remove.TabIndex = 3;
            btn_remove.Text = "Remove";
            btn_remove.Click += btn_remove_Click;
            // 
            // btn_addFile
            // 
            btn_addFile.Location = new Point(55, 137);
            btn_addFile.Name = "btn_addFile";
            btn_addFile.Size = new Size(130, 31);
            btn_addFile.TabIndex = 1;
            btn_addFile.Text = "Add File(s)";
            btn_addFile.Click += btn_addFile_Click;
            // 
            // listBoxPaths
            // 
            listBoxPaths.FormattingEnabled = true;
            listBoxPaths.ItemHeight = 15;
            listBoxPaths.Location = new Point(6, 22);
            listBoxPaths.Name = "listBoxPaths";
            listBoxPaths.Size = new Size(360, 109);
            listBoxPaths.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(textBox_password);
            groupBox3.Controls.Add(button_decrypt);
            groupBox3.Controls.Add(button_Encrypt);
            groupBox3.Controls.Add(button_showpass);
            groupBox3.Location = new Point(11, 226);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(372, 140);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Encryption";
            // 
            // textBox_password
            // 
            textBox_password.Location = new Point(97, 37);
            textBox_password.Name = "textBox_password";
            textBox_password.Size = new Size(264, 23);
            textBox_password.TabIndex = 3;
            // 
            // button_decrypt
            // 
            button_decrypt.Location = new Point(214, 76);
            button_decrypt.Name = "button_decrypt";
            button_decrypt.Size = new Size(130, 39);
            button_decrypt.TabIndex = 2;
            button_decrypt.Text = "Decrypt";
            button_decrypt.UseVisualStyleBackColor = true;
            button_decrypt.Click += button_decrypt_Click;
            // 
            // button_Encrypt
            // 
            button_Encrypt.Location = new Point(31, 76);
            button_Encrypt.Name = "button_Encrypt";
            button_Encrypt.Size = new Size(130, 39);
            button_Encrypt.TabIndex = 1;
            button_Encrypt.Text = "Encrypt";
            button_Encrypt.UseVisualStyleBackColor = true;
            button_Encrypt.Click += button_Encrypt_Click;
            // 
            // button_showpass
            // 
            button_showpass.Location = new Point(7, 37);
            button_showpass.Name = "button_showpass";
            button_showpass.Size = new Size(75, 23);
            button_showpass.TabIndex = 0;
            button_showpass.Text = "Show";
            button_showpass.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(comboBox_getAlgorithm);
            groupBox4.Controls.Add(checkBox_deleteOriginalfile);
            groupBox4.Location = new Point(10, 139);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(373, 72);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Settings";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(201, 34);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 2;
            label1.Text = "Algorithm";
            // 
            // comboBox_getAlgorithm
            // 
            comboBox_getAlgorithm.FormattingEnabled = true;
            comboBox_getAlgorithm.Location = new Point(268, 29);
            comboBox_getAlgorithm.Name = "comboBox_getAlgorithm";
            comboBox_getAlgorithm.Size = new Size(93, 23);
            comboBox_getAlgorithm.TabIndex = 1;
            // 
            // checkBox_deleteOriginalfile
            // 
            checkBox_deleteOriginalfile.AutoSize = true;
            checkBox_deleteOriginalfile.Location = new Point(13, 33);
            checkBox_deleteOriginalfile.Name = "checkBox_deleteOriginalfile";
            checkBox_deleteOriginalfile.Size = new Size(130, 19);
            checkBox_deleteOriginalfile.TabIndex = 0;
            checkBox_deleteOriginalfile.Text = "Delete Original Files";
            checkBox_deleteOriginalfile.UseVisualStyleBackColor = true;
            checkBox_deleteOriginalfile.CheckedChanged += checkBox_deleteOriginalfile_CheckedChanged;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(btn_createzip);
            groupBox5.Controls.Add(btn_examine);
            groupBox5.Controls.Add(textBox_Examine);
            groupBox5.Location = new Point(12, 12);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(372, 121);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Create zip";
            // 
            // btn_createzip
            // 
            btn_createzip.Location = new Point(12, 69);
            btn_createzip.Name = "btn_createzip";
            btn_createzip.Size = new Size(348, 35);
            btn_createzip.TabIndex = 2;
            btn_createzip.Text = "Create zip";
            btn_createzip.UseVisualStyleBackColor = true;
            btn_createzip.Click += btn_createzip_Click;
            // 
            // btn_examine
            // 
            btn_examine.Location = new Point(6, 25);
            btn_examine.Name = "btn_examine";
            btn_examine.Size = new Size(75, 23);
            btn_examine.TabIndex = 1;
            btn_examine.Text = "Examine...";
            btn_examine.UseVisualStyleBackColor = true;
            btn_examine.Click += btn_examine_Click;
            // 
            // textBox_Examine
            // 
            textBox_Examine.Location = new Point(87, 25);
            textBox_Examine.Name = "textBox_Examine";
            textBox_Examine.Size = new Size(273, 23);
            textBox_Examine.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 382);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Encryptify";
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private ListBox listBox_logs;
        private ListBox listBoxPaths;
        private ComboBox comboBox_getAlgorithm;
        private CheckBox checkBox_deleteOriginalfile;
        private GroupBox groupBox5;
        private TextBox textBox_Examine;
        private Button btn_addFile;
        private Button button_decrypt;
        private Button button_Encrypt;
        private Button button_showpass;
        private Label label1;
        private Button btn_createzip;
        private Button btn_examine;
        private TextBox textBox_password;
        private Button btn_remove;
    }
}

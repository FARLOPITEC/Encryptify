namespace Encryptify
{
    partial class Encryptify
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
            button_selectFolder = new Button();
            button_createZipFile = new Button();
            button_encryptfile = new Button();
            button_showPass = new Button();
            button_encrypt = new Button();
            button_decrypt = new Button();
            comboBox_algorithms = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // button_selectFolder
            // 
            button_selectFolder.Location = new Point(14, 14);
            button_selectFolder.Margin = new Padding(4, 3, 4, 3);
            button_selectFolder.Name = "button_selectFolder";
            button_selectFolder.Size = new Size(88, 27);
            button_selectFolder.TabIndex = 0;
            button_selectFolder.Text = "Select Folder";
            button_selectFolder.UseVisualStyleBackColor = true;
            button_selectFolder.Click += button_selectFolder_Click;
            // 
            // button_createZipFile
            // 
            button_createZipFile.Location = new Point(14, 47);
            button_createZipFile.Margin = new Padding(4, 3, 4, 3);
            button_createZipFile.Name = "button_createZipFile";
            button_createZipFile.Size = new Size(302, 27);
            button_createZipFile.TabIndex = 1;
            button_createZipFile.Text = "Create ZIP";
            button_createZipFile.UseVisualStyleBackColor = true;
            button_createZipFile.Click += button_createZipFile_Click;
            // 
            // button_encryptfile
            // 
            button_encryptfile.Location = new Point(14, 81);
            button_encryptfile.Margin = new Padding(4, 3, 4, 3);
            button_encryptfile.Name = "button_encryptfile";
            button_encryptfile.Size = new Size(88, 27);
            button_encryptfile.TabIndex = 2;
            button_encryptfile.Text = "Select File";
            button_encryptfile.UseVisualStyleBackColor = true;
            button_encryptfile.Click += button_encryptfile_Click;
            // 
            // button_showPass
            // 
            button_showPass.Location = new Point(14, 114);
            button_showPass.Margin = new Padding(4, 3, 4, 3);
            button_showPass.Name = "button_showPass";
            button_showPass.Size = new Size(88, 27);
            button_showPass.TabIndex = 3;
            button_showPass.Text = "Show Pass";
            button_showPass.UseVisualStyleBackColor = true;
            button_showPass.Click += button_showPass_Click;
            // 
            // button_encrypt
            // 
            button_encrypt.Location = new Point(118, 147);
            button_encrypt.Margin = new Padding(4, 3, 4, 3);
            button_encrypt.Name = "button_encrypt";
            button_encrypt.Size = new Size(88, 27);
            button_encrypt.TabIndex = 6;
            button_encrypt.Text = "Encrypt";
            button_encrypt.UseVisualStyleBackColor = true;
            button_encrypt.Click += button_encrypt_Click;
            // 
            // button_decrypt
            // 
            button_decrypt.Location = new Point(214, 147);
            button_decrypt.Margin = new Padding(4, 3, 4, 3);
            button_decrypt.Name = "button_decrypt";
            button_decrypt.Size = new Size(88, 27);
            button_decrypt.TabIndex = 7;
            button_decrypt.Text = "Decrypt";
            button_decrypt.UseVisualStyleBackColor = true;
            button_decrypt.Click += button_decrypt_Click;
            // 
            // comboBox_algorithms
            // 
            comboBox_algorithms.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_algorithms.FormattingEnabled = true;
            comboBox_algorithms.Items.AddRange(new object[] { "AES", "DES", "TripleDES" });
            comboBox_algorithms.Location = new Point(14, 147);
            comboBox_algorithms.Name = "comboBox_algorithms";
            comboBox_algorithms.Size = new Size(88, 23);
            comboBox_algorithms.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(108, 16);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(208, 23);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(108, 83);
            textBox2.Margin = new Padding(4, 3, 4, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(208, 23);
            textBox2.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(108, 117);
            textBox3.Margin = new Padding(4, 3, 4, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(208, 23);
            textBox3.TabIndex = 5;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // Encryptify
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(326, 181);
            Controls.Add(comboBox_algorithms);
            Controls.Add(textBox2);
            Controls.Add(button_decrypt);
            Controls.Add(button_encrypt);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(button_showPass);
            Controls.Add(button_encryptfile);
            Controls.Add(button_createZipFile);
            Controls.Add(button_selectFolder);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Encryptify";
            Text = "Encryptify";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button_selectFolder;
        private System.Windows.Forms.Button button_createZipFile;
        private System.Windows.Forms.Button button_encryptfile;
        private System.Windows.Forms.Button button_showPass;
        private System.Windows.Forms.Button button_encrypt;
        private System.Windows.Forms.Button button_decrypt;
        private System.Windows.Forms.ComboBox comboBox_algorithms;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}

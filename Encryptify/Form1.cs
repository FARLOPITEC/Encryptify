using System;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Encryptify
{
    public partial class Form1 : Form
    {
        private string folderPath = string.Empty; // Inicialización de la variable folderPath
        private bool isPasswordVisible = false; // Declaración de la variable isPasswordVisible

        public Form1()
        {
            InitializeComponent();
            textBox_password.UseSystemPasswordChar = true; // Ocultar la contraseña por defecto

            // Agregar algoritmos al comboBox_getAlgorithm
            comboBox_getAlgorithm.Items.Add("AES-256");
            comboBox_getAlgorithm.Items.Add("AES-128");
            comboBox_getAlgorithm.Items.Add("DES");
            comboBox_getAlgorithm.Items.Add("TripleDES");

            // Seleccionar el primer algoritmo por defecto
            comboBox_getAlgorithm.SelectedIndex = 0;

            // Vincular el evento Click del botón button_showPass al método button_showPass_Click
            button_showpass.Click += new EventHandler(button_showPass_Click);
        }

        private void LogMessage(string message)
        {
            listBox_logs.Items.Add($"{DateTime.Now}: {message}");
        }

        private void btn_addFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    listBoxPaths.Items.Add(openFileDialog.FileName);
                    LogMessage($"Archivo añadido: {openFileDialog.FileName}");
                }
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            if (listBoxPaths.SelectedItem != null)
            {
                LogMessage($"Elemento eliminado: {listBoxPaths.SelectedItem}");
                listBoxPaths.Items.Remove(listBoxPaths.SelectedItem);
            }
        }

        private void btn_examine_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder to be zipped";
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    folderPath = folderDialog.SelectedPath;
                    this.textBox_Examine.Text = folderPath; // Mostrar la ruta de la carpeta en textBox1
                    LogMessage($"Carpeta seleccionada para comprimir: {folderPath}");
                }
            }
        }

        private void btn_createzip_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(folderPath))
                {
                    MessageBox.Show("Please select a folder first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogMessage("Error: No se ha seleccionado ninguna carpeta.");
                    return;
                }

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "ZIP files|*.zip";
                    saveDialog.Title = "Save ZIP File";
                    saveDialog.FileName = Path.GetFileName(folderPath) + ".zip";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string zipFilePath = saveDialog.FileName;

                        try
                        {
                            // Crear el archivo ZIP
                            ZipFile.CreateFromDirectory(folderPath, zipFilePath);
                            MessageBox.Show("ZIP file created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LogMessage($"Archivo ZIP creado: {zipFilePath}");
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LogMessage($"Error al crear el archivo ZIP: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogMessage($"Unexpected error: {ex.Message}");
            }
        }

        private void EncryptFile(string inputFile, string outputFile, string password, string algorithm)
        {
            byte[] key, iv;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, 16, 10000, HashAlgorithmName.SHA256))
            {
                switch (algorithm)
                {
                    case "AES-256":
                        key = deriveBytes.GetBytes(32); // 256 bits
                        iv = deriveBytes.GetBytes(16); // 128 bits
                        break;
                    case "AES-128":
                        key = deriveBytes.GetBytes(16); // 128 bits
                        iv = deriveBytes.GetBytes(16); // 128 bits
                        break;
                    case "DES":
                        key = deriveBytes.GetBytes(8); // 64 bits
                        iv = deriveBytes.GetBytes(8); // 64 bits
                        break;
                    case "TripleDES":
                        key = deriveBytes.GetBytes(24); // 192 bits
                        iv = deriveBytes.GetBytes(8); // 64 bits
                        break;
                    default:
                        throw new NotSupportedException("Algorithm not supported");
                }
            }

            using (FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (FileStream fsEncrypted = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            using (var cryptoStream = new CryptoStream(fsEncrypted, GetAlgorithm(algorithm, key, iv).CreateEncryptor(), CryptoStreamMode.Write))
            {
                fsInput.CopyTo(cryptoStream);
            }
        }

        private void button_Encrypt_Click(object sender, EventArgs e)
        {
            if (listBoxPaths.Items.Count == 0 || string.IsNullOrEmpty(textBox_password.Text))
            {
                MessageBox.Show("Please add files and enter a password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string algorithm = comboBox_getAlgorithm.SelectedItem?.ToString() ?? string.Empty;
            if (string.IsNullOrEmpty(algorithm))
            {
                MessageBox.Show("Please select an encryption algorithm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (string filePath in listBoxPaths.Items)
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    string extension = algorithm switch
                    {
                        "AES-256" => ".aes",
                        "AES-128" => ".aes",
                        "DES" => ".des",
                        "TripleDES" => ".3des",
                        _ => ".enc"
                    };

                    saveDialog.Filter = $"Encrypted files|*{extension}";
                    saveDialog.Title = "Save Encrypted File";
                    saveDialog.FileName = Path.GetFileName(filePath) + extension;

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string encryptedFilePath = saveDialog.FileName;

                        try
                        {
                            EncryptFile(filePath, encryptedFilePath, textBox_password.Text, algorithm);
                            MessageBox.Show($"File {filePath} encrypted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LogMessage($"Archivo encriptado: {encryptedFilePath}");

                            // Eliminar el archivo original si la opción está marcada
                            if (checkBox_deleteOriginalfile.Checked)
                            {
                                File.Delete(filePath);
                                LogMessage($"Archivo original eliminado: {filePath}");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LogMessage($"Error al encriptar el archivo {filePath}: {ex.Message}");
                        }
                    }
                }
            }
        }


        private void button_decrypt_Click(object sender, EventArgs e)
        {
            if (listBoxPaths.Items.Count == 0 || string.IsNullOrEmpty(textBox_password.Text))
            {
                MessageBox.Show("Please add files and enter a password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string algorithm = comboBox_getAlgorithm.SelectedItem?.ToString() ?? string.Empty;
            if (string.IsNullOrEmpty(algorithm))
            {
                MessageBox.Show("Please select an encryption algorithm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (string filePath in listBoxPaths.Items)
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "All files|*.*";
                    saveDialog.Title = "Save Decrypted File";
                    saveDialog.FileName = Path.GetFileNameWithoutExtension(filePath);

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        string decryptedFilePath = saveDialog.FileName;

                        try
                        {
                            DecryptFile(filePath, decryptedFilePath, textBox_password.Text, algorithm);
                            MessageBox.Show($"File {filePath} decrypted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LogMessage($"Archivo desencriptado: {decryptedFilePath}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            LogMessage($"Error al desencriptar el archivo {filePath}: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void DecryptFile(string inputFile, string outputFile, string password, string algorithm)
        {
            byte[] key, iv;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, 16, 10000, HashAlgorithmName.SHA256))
            {
                key = deriveBytes.GetBytes(32); // 256 bits
                iv = deriveBytes.GetBytes(16); // 128 bits
            }

            using (FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (FileStream fsDecrypted = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            using (var cryptoStream = new CryptoStream(fsInput, GetAlgorithm(algorithm, key, iv).CreateDecryptor(), CryptoStreamMode.Read))
            {
                cryptoStream.CopyTo(fsDecrypted);
            }
        }

        private SymmetricAlgorithm GetAlgorithm(string algorithm, byte[] key, byte[] iv)
        {
            SymmetricAlgorithm algo;
            switch (algorithm)
            {
                case "AES-256":
                    algo = Aes.Create();
                    algo.KeySize = 256; // Asegurar que AES use una clave de 256 bits
                    break;
                case "AES-128":
                    algo = Aes.Create();
                    algo.KeySize = 128; // Asegurar que AES use una clave de 128 bits
                    break;
                case "DES":
                    algo = DES.Create();
                    break;
                case "TripleDES":
                    algo = TripleDES.Create();
                    break;
                default:
                    throw new NotSupportedException("Algorithm not supported");
            }
            algo.Key = key;
            algo.IV = iv;
            return algo;
        }

        private void button_showPass_Click(object? sender, EventArgs? e)
        {
            isPasswordVisible = !isPasswordVisible; // Alternar el estado de visibilidad de la contraseña
            textBox_password.UseSystemPasswordChar = !isPasswordVisible; // Mostrar u ocultar la contraseña
        }

        private void checkBox_deleteOriginalfile_CheckedChanged(object? sender, EventArgs? e)
        {

        }
    }
}

using System;
using System.Windows.Forms;
using System.IO.Compression;
using System.Security.Cryptography;
using System.IO;

namespace Encryptify
{
    public partial class Encryptify : Form
    {
        private bool isPasswordVisible = false; // Variable para rastrear el estado de visibilidad de la contraseña
        private string folderPath = string.Empty; // Inicializar la variable para evitar valores NULL
        private string filePath = string.Empty; // Inicializar la variable para la ruta del archivo a encriptar

        public Encryptify()
        {
            InitializeComponent();
            textBox3.UseSystemPasswordChar = true; // Configurar textBox3 para contraseñas
        }

        private void button_selectFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new())
            {
                folderDialog.Description = "Select a folder to be zipped";
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    folderPath = folderDialog.SelectedPath;
                    this.textBox1.Text = folderPath; // Mostrar la ruta de la carpeta en textBox1
                }
            }
        }

        private void button_createZipFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(folderPath))
            {
                MessageBox.Show("Please select a folder first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button_encryptfile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new())
            {
                openDialog.Filter = "All files|*.*";
                openDialog.Title = "Open a file to be encrypted";
                openDialog.Multiselect = false;

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openDialog.FileName;
                    this.textBox2.Text = filePath; // Mostrar la ruta del archivo en textBox2
                }
            }
        }

        private void button_encrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please select a file and enter a password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string algorithm = comboBox_algorithms.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(algorithm))
            {
                MessageBox.Show("Please select an encryption algorithm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Encrypted files|*.enc";
                saveDialog.Title = "Save Encrypted File";
                saveDialog.FileName = Path.GetFileName(filePath) + ".enc";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    string encryptedFilePath = saveDialog.FileName;

                    try
                    {
                        EncryptFile(filePath, encryptedFilePath, textBox3.Text, algorithm);
                        MessageBox.Show("File encrypted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button_decrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please select a file and enter a password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string algorithm = comboBox_algorithms.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(algorithm))
            {
                MessageBox.Show("Please select an encryption algorithm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
                        DecryptFile(filePath, decryptedFilePath, textBox3.Text, algorithm);
                        MessageBox.Show("File decrypted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Aquí puedes agregar lógica adicional si es necesario
        }

        private void button_showPass_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible; // Alternar el estado de visibilidad de la contraseña
            textBox3.UseSystemPasswordChar = !isPasswordVisible; // Mostrar u ocultar la contraseña
        }

        private void EncryptFile(string inputFile, string outputFile, string password, string algorithm)
        {
            byte[] key, iv;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, 16))
            {
                key = deriveBytes.GetBytes(32); // 256 bits
                iv = deriveBytes.GetBytes(16); // 128 bits
            }

            using (FileStream fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (FileStream fsEncrypted = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            using (var cryptoStream = new CryptoStream(fsEncrypted, GetAlgorithm(algorithm, key, iv).CreateEncryptor(), CryptoStreamMode.Write))
            {
                fsInput.CopyTo(cryptoStream);
            }
        }

        private void DecryptFile(string inputFile, string outputFile, string password, string algorithm)
        {
            byte[] key, iv;
            using (var deriveBytes = new Rfc2898DeriveBytes(password, 16))
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
                case "AES":
                    algo = Aes.Create();
                    algo.KeySize = 256; // Asegurar que AES use una clave de 256 bits
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
    }
}

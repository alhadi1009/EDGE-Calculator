using System;
using System.IO;
using System.Windows.Forms;

namespace FileTransferApp
{
    public partial class DestinationForm : Form
    {
        private readonly string sourcePath;
        private readonly bool isFolder;
        private readonly string operation; // "Copy" or "Cut"
        private string destFolder = string.Empty;

        // Constructor receives everything decided on the Source form
        public DestinationForm(string sourcePath, bool isFolder, string operation)
        {
            InitializeComponent();
            this.sourcePath = sourcePath;
            this.isFolder = isFolder;
            this.operation = operation;

            string itemName = Path.GetFileName(sourcePath.TrimEnd(Path.DirectorySeparatorChar));
            lblInfo.Text = $"Pending action: {operation} \"{itemName}\" ({(isFolder ? "Folder" : "File")})";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select the destination folder";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    destFolder = fbd.SelectedPath;
                    txtDestPath.Text = destFolder;
                }
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(destFolder))
            {
                MessageBox.Show(
                    "Please browse and select a destination folder first.",
                    "No Destination",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string itemName = Path.GetFileName(sourcePath.TrimEnd(Path.DirectorySeparatorChar));
                string destPath = Path.Combine(destFolder, itemName);

                // Prevent copying/moving a folder into itself or a subfolder of itself
                if (isFolder && destPath.StartsWith(sourcePath, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "You cannot paste a folder into itself or one of its own subfolders.",
                        "Invalid Destination",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                if (isFolder)
                {
                    if (operation == "Copy")
                    {
                        CopyDirectoryRecursive(sourcePath, destPath);
                    }
                    else // Cut
                    {
                        if (Directory.Exists(destPath))
                        {
                            MessageBox.Show("A folder with the same name already exists at the destination.");
                            return;
                        }
                        Directory.Move(sourcePath, destPath);
                    }
                }
                else
                {
                    if (operation == "Copy")
                    {
                        File.Copy(sourcePath, destPath, true);
                    }
                    else // Cut
                    {
                        if (File.Exists(destPath))
                        {
                            File.Delete(destPath);
                        }
                        File.Move(sourcePath, destPath);
                    }
                }

                MessageBox.Show(
                    $"{operation} completed successfully!\n\n{itemName} -> {destFolder}",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                lblInfo.Text = $"Done: {operation} completed for \"{itemName}\"";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Operation Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Recursively copies a folder and all its contents to a new location
        private void CopyDirectoryRecursive(string sourceDir, string destDir)
        {
            Directory.CreateDirectory(destDir);

            foreach (string file in Directory.GetFiles(sourceDir))
            {
                string destFile = Path.Combine(destDir, Path.GetFileName(file));
                File.Copy(file, destFile, true);
            }

            foreach (string subDir in Directory.GetDirectories(sourceDir))
            {
                string destSubDir = Path.Combine(destDir, Path.GetFileName(subDir));
                CopyDirectoryRecursive(subDir, destSubDir);
            }
        }
    }
}

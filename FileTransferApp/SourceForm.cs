using System;
using System.IO;
using System.Windows.Forms;

namespace FileTransferApp
{
    public partial class SourceForm : Form
    {
        // Holds the path the user picked (file OR folder)
        private string selectedPath = string.Empty;
        private bool isFolder = false;

        public SourceForm()
        {
            InitializeComponent();
        }

        // Browse button: lets the user pick either a FILE or a FOLDER
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var choice = MessageBox.Show(
                "Click YES to browse a FOLDER, or NO to browse a FILE.",
                "Select Type",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (choice == DialogResult.Yes)
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Select a source folder";
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        selectedPath = fbd.SelectedPath;
                        isFolder = true;
                        txtSourcePath.Text = selectedPath;
                        lblStatus.Text = "Folder selected: " + Path.GetFileName(selectedPath);
                    }
                }
            }
            else if (choice == DialogResult.No)
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = "Select a source file";
                    ofd.Filter = "All files (*.*)|*.*";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        selectedPath = ofd.FileName;
                        isFolder = false;
                        txtSourcePath.Text = selectedPath;
                        lblStatus.Text = "File selected: " + Path.GetFileName(selectedPath);
                    }
                }
            }
            // Cancel -> do nothing
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            OpenDestination("Copy");
        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            OpenDestination("Cut");
        }

        // Validates selection then opens the Destination form, passing along
        // the source path, whether it's a folder, and the chosen operation.
        private void OpenDestination(string operation)
        {
            if (string.IsNullOrWhiteSpace(selectedPath) ||
                (isFolder && !Directory.Exists(selectedPath)) ||
                (!isFolder && !File.Exists(selectedPath)))
            {
                MessageBox.Show(
                    "Please browse and select a valid file or folder first.",
                    "Nothing Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            lblStatus.Text = operation + " pending - go to Destination window...";

            var destinationForm = new DestinationForm(selectedPath, isFolder, operation);
            destinationForm.FormClosed += (s, args) =>
            {
                // When the user finishes (or cancels) in Destination form,
                // this Source window regains focus.
                this.Show();
                this.Activate();
            };
            this.Hide();
            destinationForm.Show();
        }
    }
}

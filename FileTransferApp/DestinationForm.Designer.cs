namespace FileTransferApp
{
    partial class DestinationForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtDestPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(190, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Destination Location";
            //
            // lblInfo
            //
            this.lblInfo.AutoSize = true;
            this.lblInfo.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblInfo.Location = new System.Drawing.Point(20, 55);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(100, 15);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "Ready...";
            //
            // txtDestPath
            //
            this.txtDestPath.Location = new System.Drawing.Point(20, 80);
            this.txtDestPath.Name = "txtDestPath";
            this.txtDestPath.ReadOnly = true;
            this.txtDestPath.Size = new System.Drawing.Size(430, 23);
            this.txtDestPath.TabIndex = 2;
            //
            // btnBrowse
            //
            this.btnBrowse.Location = new System.Drawing.Point(20, 120);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(200, 35);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "Browse Destination Folder";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            //
            // btnPaste
            //
            this.btnPaste.Location = new System.Drawing.Point(250, 120);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(200, 35);
            this.btnPaste.TabIndex = 4;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            //
            // DestinationForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 200);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtDestPath);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DestinationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Destination - File/Folder Copy Cut Paste Lab";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox txtDestPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnPaste;
    }
}

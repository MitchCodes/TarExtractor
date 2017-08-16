namespace TarExtractor_Docker {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblTarFile = new System.Windows.Forms.Label();
            this.tbInputFile = new System.Windows.Forms.TextBox();
            this.btnBrowseInput = new System.Windows.Forms.Button();
            this.lblTopNote = new System.Windows.Forms.Label();
            this.fileInputDialog = new System.Windows.Forms.OpenFileDialog();
            this.lblDockerLabel = new System.Windows.Forms.Label();
            this.btnBrowseOutput = new System.Windows.Forms.Button();
            this.tbOutputFolder = new System.Windows.Forms.TextBox();
            this.lblOutputFolder = new System.Windows.Forms.Label();
            this.folderOutputDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnExtract = new System.Windows.Forms.Button();
            this.btnInstallPage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTarFile
            // 
            this.lblTarFile.AutoSize = true;
            this.lblTarFile.Location = new System.Drawing.Point(12, 188);
            this.lblTarFile.Name = "lblTarFile";
            this.lblTarFile.Size = new System.Drawing.Size(72, 13);
            this.lblTarFile.TabIndex = 0;
            this.lblTarFile.Text = "Input Tar File:";
            // 
            // tbInputFile
            // 
            this.tbInputFile.Location = new System.Drawing.Point(90, 185);
            this.tbInputFile.Name = "tbInputFile";
            this.tbInputFile.ReadOnly = true;
            this.tbInputFile.Size = new System.Drawing.Size(210, 20);
            this.tbInputFile.TabIndex = 1;
            // 
            // btnBrowseInput
            // 
            this.btnBrowseInput.Location = new System.Drawing.Point(306, 183);
            this.btnBrowseInput.Name = "btnBrowseInput";
            this.btnBrowseInput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseInput.TabIndex = 2;
            this.btnBrowseInput.Text = "Browse";
            this.btnBrowseInput.UseVisualStyleBackColor = true;
            this.btnBrowseInput.Click += new System.EventHandler(this.btnBrowseInput_Click);
            // 
            // lblTopNote
            // 
            this.lblTopNote.AutoSize = true;
            this.lblTopNote.Location = new System.Drawing.Point(12, 9);
            this.lblTopNote.Name = "lblTopNote";
            this.lblTopNote.Size = new System.Drawing.Size(384, 117);
            this.lblTopNote.TabIndex = 3;
            this.lblTopNote.Text = resources.GetString("lblTopNote.Text");
            // 
            // fileInputDialog
            // 
            this.fileInputDialog.Filter = "Tar files|*.tar";
            // 
            // lblDockerLabel
            // 
            this.lblDockerLabel.AutoSize = true;
            this.lblDockerLabel.Location = new System.Drawing.Point(15, 151);
            this.lblDockerLabel.Name = "lblDockerLabel";
            this.lblDockerLabel.Size = new System.Drawing.Size(0, 13);
            this.lblDockerLabel.TabIndex = 4;
            // 
            // btnBrowseOutput
            // 
            this.btnBrowseOutput.Location = new System.Drawing.Point(306, 209);
            this.btnBrowseOutput.Name = "btnBrowseOutput";
            this.btnBrowseOutput.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseOutput.TabIndex = 7;
            this.btnBrowseOutput.Text = "Browse";
            this.btnBrowseOutput.UseVisualStyleBackColor = true;
            this.btnBrowseOutput.Click += new System.EventHandler(this.btnBrowseOutput_Click);
            // 
            // tbOutputFolder
            // 
            this.tbOutputFolder.Location = new System.Drawing.Point(90, 211);
            this.tbOutputFolder.Name = "tbOutputFolder";
            this.tbOutputFolder.ReadOnly = true;
            this.tbOutputFolder.Size = new System.Drawing.Size(210, 20);
            this.tbOutputFolder.TabIndex = 6;
            // 
            // lblOutputFolder
            // 
            this.lblOutputFolder.AutoSize = true;
            this.lblOutputFolder.Location = new System.Drawing.Point(12, 214);
            this.lblOutputFolder.Name = "lblOutputFolder";
            this.lblOutputFolder.Size = new System.Drawing.Size(74, 13);
            this.lblOutputFolder.TabIndex = 5;
            this.lblOutputFolder.Text = "Output Folder:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 264);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 13);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status: Idle";
            // 
            // btnExtract
            // 
            this.btnExtract.Location = new System.Drawing.Point(15, 308);
            this.btnExtract.Name = "btnExtract";
            this.btnExtract.Size = new System.Drawing.Size(366, 23);
            this.btnExtract.TabIndex = 9;
            this.btnExtract.Text = "Extract";
            this.btnExtract.UseVisualStyleBackColor = true;
            this.btnExtract.Click += new System.EventHandler(this.btnExtract_Click);
            // 
            // btnInstallPage
            // 
            this.btnInstallPage.Enabled = false;
            this.btnInstallPage.Location = new System.Drawing.Point(272, 146);
            this.btnInstallPage.Name = "btnInstallPage";
            this.btnInstallPage.Size = new System.Drawing.Size(109, 23);
            this.btnInstallPage.TabIndex = 10;
            this.btnInstallPage.Text = "Go To Install Page";
            this.btnInstallPage.UseVisualStyleBackColor = true;
            this.btnInstallPage.Visible = false;
            this.btnInstallPage.Click += new System.EventHandler(this.btnInstallPage_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 343);
            this.Controls.Add(this.btnInstallPage);
            this.Controls.Add(this.btnExtract);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnBrowseOutput);
            this.Controls.Add(this.tbOutputFolder);
            this.Controls.Add(this.lblOutputFolder);
            this.Controls.Add(this.lblDockerLabel);
            this.Controls.Add(this.lblTopNote);
            this.Controls.Add(this.btnBrowseInput);
            this.Controls.Add(this.tbInputFile);
            this.Controls.Add(this.lblTarFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Tar Extractor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTarFile;
        private System.Windows.Forms.TextBox tbInputFile;
        private System.Windows.Forms.Button btnBrowseInput;
        private System.Windows.Forms.Label lblTopNote;
        private System.Windows.Forms.OpenFileDialog fileInputDialog;
        private System.Windows.Forms.Label lblDockerLabel;
        private System.Windows.Forms.Button btnBrowseOutput;
        private System.Windows.Forms.TextBox tbOutputFolder;
        private System.Windows.Forms.Label lblOutputFolder;
        private System.Windows.Forms.FolderBrowserDialog folderOutputDialog;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnExtract;
        private System.Windows.Forms.Button btnInstallPage;
    }
}


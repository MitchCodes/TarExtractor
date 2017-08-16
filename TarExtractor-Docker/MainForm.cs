using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TarExtractor_Docker {
    public partial class MainForm : Form {

        private string InputTarFileFullPath { get; set; }
        private string OutputFolderPath { get; set; }
        private TarExtractionService ExtractionService { get; }

        public MainForm() {
            ExtractionService = new TarExtractionService();
            InitializeComponent();
            if (!HasDocker()) HandleNoDocker();
        }

        private bool HasDocker() {
            Process process = ExtractionService.ExecuteCmd("/c docker");
            string output = process.StandardError.ReadToEnd();
            if (output.Contains("is not recognized as an internal or external")) {
                return false;
            }
            return true;
        }

        private void HandleNoDocker() {
            btnBrowseInput.Enabled = false;
            btnBrowseOutput.Enabled = false;
            btnExtract.Enabled = false;
            lblDockerLabel.ForeColor = Color.Red;
            lblDockerLabel.Text = "It appears that you do not have Docker installed.";
            btnInstallPage.Visible = true;
            btnInstallPage.Enabled = true;
        }

        

        private void btnBrowseInput_Click(object sender, EventArgs e) {
            if (fileInputDialog.ShowDialog() == DialogResult.OK) {
                if (!String.IsNullOrWhiteSpace(fileInputDialog.FileName) && File.Exists(fileInputDialog.FileName)) {
                    InputTarFileFullPath = fileInputDialog.FileName;
                    tbInputFile.Text = Path.GetFileName(InputTarFileFullPath);
                }
            }
        }

        private void btnBrowseOutput_Click(object sender, EventArgs e) {
            if (folderOutputDialog.ShowDialog() == DialogResult.OK) {
                if (!String.IsNullOrWhiteSpace(folderOutputDialog.SelectedPath) && Directory.Exists(folderOutputDialog.SelectedPath)) {
                    OutputFolderPath = folderOutputDialog.SelectedPath;
                    tbOutputFolder.Text = OutputFolderPath;
                }
            }
        }

        private void btnExtract_Click(object sender, EventArgs e) {
            if (!String.IsNullOrWhiteSpace(InputTarFileFullPath) && !String.IsNullOrWhiteSpace(OutputFolderPath)) {
                lblStatus.Text = "Status: Extracting";
                try {
                    ExtractionService.ExtractTarWithDocker(InputTarFileFullPath, OutputFolderPath);
                    lblStatus.Text = "Status: Done Extracting";
                }
                catch (TarExtractionError ex) {
                    string messageToShow = "Error: " + ex.Message;
                    if (ex.InnerException != null) {
                        messageToShow += "\n\nInner Exception: " + ex.InnerException;
                    }
                    MessageBox.Show(messageToShow);
                    lblStatus.Text = "Status: Error Extracting";
                }
                catch (Exception ex) {
                    string messageToShow = "Error: " + ex;
                    if (ex.InnerException != null) {
                        messageToShow += "\n\nInner Exception: " + ex.InnerException;
                    }
                    MessageBox.Show(messageToShow);
                    lblStatus.Text = "Status: Error Extracting";
                }
            }
        }

        private void btnInstallPage_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://docs.docker.com/docker-for-windows/install/#download-docker-for-windows");
        }
    }
}

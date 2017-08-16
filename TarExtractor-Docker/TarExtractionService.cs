using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarExtractor_Docker {

    public class TarExtractionError : Exception {
        public TarExtractionError(string message) : base(message) {
            
        }
    }

    public enum TarExtractionMethodEnum {
        CopyTar = 0, // more secure
        KeepDirectory = 1 // less secure
    }

    public enum DockerContainerTypeEnum {
        Linux = 0,
        Windows = 1,
        Neither = 2
    }

    public class TarExtractionService {
        public void ExtractTarWithDocker(string inputTarPath, string outputFolderPath, TarExtractionMethodEnum method = TarExtractionMethodEnum.KeepDirectory) {
            if (!File.Exists(inputTarPath) || !Directory.Exists(outputFolderPath)) {
                return;
            }

            DockerContainerTypeEnum containerType = GetDockerContainerType();
            if (containerType == DockerContainerTypeEnum.Neither) {
                throw new TarExtractionError("Unable to retrieve Container type!");
            }

            if (containerType == DockerContainerTypeEnum.Windows) {
                throw new TarExtractionError("Container type is Windows. Must use the linux container type.");
            }

            string mountingFolder = GetMountingFolder(inputTarPath, method);
            string mountingFolderExtract = GetMountingExtractFolder(mountingFolder, method);
            string inputTarFileExt = Path.GetFileName(inputTarPath);
            string mountingFolderExtractName = Path.GetFileName(Path.GetDirectoryName(mountingFolderExtract + @"\\doesntmatter.tar")); ;

            try {
                Process proc = ExecuteCmd("/c docker run --rm -v " + mountingFolder + ":" + "/data ubuntu tar -xf /data/" + inputTarFileExt + " -C /data/" + mountingFolderExtractName);
                string output = proc.StandardError.ReadToEnd();
                if (!String.IsNullOrWhiteSpace(output)) {
                    Console.Error.Write(output);
                    if (output.Contains("indicate that the docker daemon is not running")) {
                        throw new TarExtractionError("Docker is not running!");
                    } else if (output.ToLower().Contains("ignoring unknown extended header")) {
                        // do nothing
                    } else { 
                        throw new Exception(output);
                    }
                }

                Console.Write(proc.StandardOutput.ReadToEnd());

                MoveFilesToOutput(mountingFolderExtract, outputFolderPath);

                DeleteDirectory(mountingFolderExtract);
                if (method == TarExtractionMethodEnum.CopyTar) {
                    DeleteDirectory(mountingFolder);
                }
            }
            catch (Exception ex) {
                try {
                    DeleteDirectory(mountingFolderExtract);
                    if (method == TarExtractionMethodEnum.CopyTar) {
                        DeleteDirectory(mountingFolder);
                    }
                }
                catch (Exception subEx) {
                    throw new Exception(ex.Message, subEx);
                }
                throw ex;
            }

        }

        private string GetMountingFolder(string inputTarPath, TarExtractionMethodEnum method) {
            if (method == TarExtractionMethodEnum.CopyTar) {
                return CreateTempDirectoryAndCopy(inputTarPath);
            } else if (method == TarExtractionMethodEnum.KeepDirectory) {
                return Path.GetDirectoryName(inputTarPath);
            }
            return null;
        }

        private string GetMountingExtractFolder(string mountingFolder, TarExtractionMethodEnum method) {
            if (method == TarExtractionMethodEnum.CopyTar) {
                return GetExtractDirectory(mountingFolder);
            } else if (method == TarExtractionMethodEnum.KeepDirectory) {
                return CreateTempExtractionDirectory(mountingFolder);
            }
            return null;
        }

        private string CreateTempDirectoryAndCopy(string inputTarPath) {
            string inputFileNoExt = Path.GetFileNameWithoutExtension(inputTarPath);
            string directory = Path.Combine(Path.GetTempPath(), "tarextract-" + inputFileNoExt + "-" + (new Random().Next(1,5000)));
            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }
            string directoryExtract = GetExtractDirectory(directory);
            if (!Directory.Exists(directoryExtract)) {
                Directory.CreateDirectory(directoryExtract);
            }

            string inputFileExt = Path.GetFileName(inputTarPath);
            File.Copy(inputTarPath, Path.Combine(directory, inputFileExt));
            return directory;
        }

        private string CreateTempExtractionDirectory(string mountingFolder) {
            string directory = Path.Combine(mountingFolder, "extract-" + (new Random().Next(1, 500000)));
            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }
            return directory;
        }

        private void MoveFilesToOutput(string extractDir, string outputDir) {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(extractDir, "*", SearchOption.AllDirectories)) {
                Directory.CreateDirectory(dirPath.Replace(extractDir, outputDir));
            }

            //Move all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(extractDir, "*.*", SearchOption.AllDirectories)) {
                if (File.Exists(newPath.Replace(extractDir, outputDir))) {
                    File.Delete(newPath.Replace(extractDir, outputDir));
                }
                File.Move(newPath, newPath.Replace(extractDir, outputDir));
            }
        }

        private void DeleteDirectory(string directory) {
            if (Directory.Exists(directory)) {
                try {
                    Directory.Delete(directory, true);
                }
                catch (UnauthorizedAccessException) {
                    throw new TarExtractionError(
                        "When deleting the temporary folder created to extract the files, the program was unable to delete the temporary folder due to lack of permission.\nThe folder path is: " +
                        directory);
                }
            }
        }

        private string GetExtractDirectory(string rootDir) {
            return Path.Combine(rootDir, "extract");
        }

        private DockerContainerTypeEnum GetDockerContainerType() {
            Process proc = ExecuteCmd("/c docker version");
            string output = proc.StandardOutput.ReadToEnd();
            if (String.IsNullOrWhiteSpace(output)) {
                return DockerContainerTypeEnum.Neither;
            }

            string[] splitClientServer = output.Split(new string[] { "Server:" }, StringSplitOptions.None);
            if (splitClientServer.Length > 1) {
                string serverStuff = splitClientServer[1]; // elegant naming
                if (serverStuff.ToLower().Contains("windows/")) {
                    return DockerContainerTypeEnum.Windows;
                }
                if (serverStuff.ToLower().Contains("linux/")) {
                    return DockerContainerTypeEnum.Linux;
                }
            }

            return DockerContainerTypeEnum.Neither;

        }

        public Process ExecuteCmd(string cmd) {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = cmd;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit(500);
            return proc;
        }
    }
}

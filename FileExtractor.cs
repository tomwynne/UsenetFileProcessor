using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace UsenetFileProcessor
{
    public class StatusEventArgs : EventArgs
    {
        public string StatusText = "";
    }

    public class FileExtractor
    {
        public event EventHandler<StatusEventArgs>? StatusAdded;
        public event EventHandler<StatusEventArgs>? StatusUpdated;

        private bool TestArchive(string archiveFile)
        {
            return TestArchive(archiveFile, "");
        }

        private bool TestArchive(string sArchiveFile, string sPassword)
        {
            if (!sArchiveFile.Contains(".rar")) return false;
            AddStatus($"Testing archive '{sArchiveFile}'...");
            var oProcess = new Process();
            ProcessStartInfo oStartInfo;
            if (sPassword == "")
                oStartInfo = new ProcessStartInfo(@"C:\Program Files\WinRAR\rar.exe", $"t -p- {sArchiveFile}");
            else
                oStartInfo = new ProcessStartInfo(@"C:\Program Files\WinRAR\rar.exe", $"t -p{sPassword} {sArchiveFile}");

            oStartInfo.CreateNoWindow = true;
            oStartInfo.UseShellExecute = false;
            oStartInfo.RedirectStandardOutput = true;
            oProcess.StartInfo = oStartInfo;
            oProcess.Start();

            string? sOutput = "";
            using (System.IO.StreamReader oStreamReader = oProcess.StandardOutput)
            {
                while (!oStreamReader.EndOfStream)
                {
                    sOutput = oStreamReader.ReadLine();
                    if (sOutput!.StartsWith("..."))
                    {
                        string sPercent = sOutput.Substring(sOutput.LastIndexOf(" ") + 1);
                        string sFilename = sOutput.Substring(12);
                        sFilename = sFilename.Substring(0, sFilename.IndexOf(" "));
                        UpdateStatus($"Testing archive {sArchiveFile}: {sFilename} - {sPercent}");
                    }
                }
                //sOutput = oStreamReader.ReadToEnd()
            }
            if (sOutput.Contains("All OK"))
            {
                UpdateStatus($"Testing archive {sArchiveFile}: OK");
                return true;
            } else {
                UpdateStatus($"Testing archive {sArchiveFile}: FAILED");
                return false;
            }

        }

        public bool ExtractArchive(string sArchiveFile, string sDestinationDirectory)
        {
            return ExtractArchive(sArchiveFile, "", sDestinationDirectory);
        }

        public bool ExtractArchive(string sArchiveFile, string sPassword, string sDestinationDirectory)
        {
            string? sOutput = "";

            if (!sArchiveFile.Contains(".rar")) return false;
            AddStatus($"Testing archive '{sArchiveFile}'...");
            using (Process oProcess = new Process())
            {
                ProcessStartInfo oStartInfo;
                if (sPassword == "")
                    oStartInfo = new ProcessStartInfo(@"C:\Program Files\WinRAR\rar.exe", $"e -y -p- {sArchiveFile} {sDestinationDirectory}");
                else
                    oStartInfo = new ProcessStartInfo(@"C:\Program Files\WinRAR\rar.exe", $"e -y -p{sPassword} {sArchiveFile} {sDestinationDirectory}");

                oStartInfo.CreateNoWindow = true;
                oStartInfo.UseShellExecute = false;
                oStartInfo.RedirectStandardOutput = true;
                oProcess.StartInfo = oStartInfo;
                oProcess.Start();

                using (System.IO.StreamReader oStreamReader = oProcess.StandardOutput)
                {
                    while (!oStreamReader.EndOfStream)
                    {
                        sOutput = oStreamReader.ReadLine();
                        if (sOutput!.StartsWith("..."))
                        {
                            string sPercent = sOutput.Substring(sOutput.LastIndexOf(" ") + 1);
                            string sFilename = sOutput.Substring(12);
                            sFilename = sFilename.Substring(0, sFilename.IndexOf(" "));
                            UpdateStatus($"Extracting archive {sArchiveFile}: {sFilename} - {sPercent}");
                        }
                    }
                    //sOutput = oStreamReader.ReadToEnd()
                }
                oProcess.Dispose();
            }
            if (sOutput.Contains("All OK"))
            {
                UpdateStatus($"Extracting archive {sArchiveFile}: OK");
                return true;
            }
            else
            {
                UpdateStatus($"Extracting archive {sArchiveFile}: FAILED");
                return false;
            }
        }

        public void ExtractArchives(string sFolderName, string sDownloadFolder)
        {
            ExtractArchives(sFolderName, sDownloadFolder, "part01.rar");
            ExtractArchives(sFolderName, sDownloadFolder, "part001.rar");
        }

        public void ExtractArchives(string sFolderName, string sDownloadFolder, string sFirstArchive)
        {
            bool bOK = false;
            if (!Directory.Exists(sFolderName)) return;
            AddStatus($"Extracting Archives in {sFolderName}");
            foreach (string sRarFilename in Directory.GetFiles(sFolderName, "*." + sFirstArchive))
            {
                string sRarFile = Path.GetFileName(sRarFilename).Replace("." + sFirstArchive, "");  // Path.GetFileNameWithoutExtension(sRarFilename).Split(".")(0)
                string sPassword = "";
                if (TestArchive(sRarFilename))
                    bOK = true;
                else
                {
                    // failed, try password as the name of the file
                    if (sRarFile.StartsWith("unknown"))
                        sPassword = "paranoid06-does-the-usenet";
                    else
                    {
                        // rar file is a number ex. 19071519
                        sPassword = sRarFile.Replace("REPOST-", "");
                        sPassword = sPassword.Replace("REPOST2-", "");
                    }
                    if (TestArchive(sRarFilename, sPassword))
                        bOK = true;
                    else
                    {
                        sPassword = "20" + sPassword;            // try with new 20 in front for dmca ones
                        if (TestArchive(sRarFilename, sPassword))
                            bOK = true;
                        else
                            bOK = false;
                    }
                }
                if (bOK)
                {
                    if (ExtractArchive(sRarFilename, sPassword, sDownloadFolder))
                    {
                        try
                        {
                            //'    If sRarFilename.StartsWith("unknownweb") Then
                            //'        MoveFile(sRarFilename, Path.Combine("e:\unknownweb", Path.GetFileName(sRarFilename)))
                            //'    ElseIf sRarFilename.StartsWith("unknowntv") Then
                            //'        MoveFile(sRarFilename, Path.Combine("e:\unknowntv", Path.GetFileName(sRarFilename)))
                            //'    Else
                            //'        MoveFile(sRarFilename, Path.Combine("e:\unknown", Path.GetFileName(sRarFilename)))
                            //'    End If
                            System.IO.File.Delete(Path.Combine(sFolderName, sRarFile + "*.*"));
                            //    Kill(Path.Combine(DownloadFolder, sRarFile & ".nfo"))
                        }
                        catch
                        {

                        }
                    }
                }
            }
            AddStatus("Complete.");
        }

        protected virtual void AddStatus(string statusText)
        {
            StatusAdded?.Invoke(this, new StatusEventArgs() { StatusText = statusText });
        }
        protected virtual void UpdateStatus(string statusText)
        {
            StatusUpdated?.Invoke(this, new StatusEventArgs() { StatusText = statusText });            
        }
    }
}

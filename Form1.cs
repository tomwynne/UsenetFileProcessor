using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Data;

namespace UsenetFileProcessor
{
    public partial class Form1 : Form
    {
        private string LastError = "";

        private string[] TVFolders = {
            @"\\Plex-server\d\TV_Comedy",
            @"\\Plex-server\d\TV_Crime",
            @"\\Plex-server\d\TV_Drama",
            @"\\Synology64\tv1\TV_Action",
            @"\\Synology64\tv1\TV_Animation",
            @"\\Synology64\tv2\TV_Documentary",
            @"\\Synology64\tv1\TV_Fantasy",
            @"\\Synology64\tv1\TV_Horror",
            @"\\Synology64\tv1\TV_Sci-Fi",
            @"\\Synology64\tv1\TV_Superheroes",
            @"\\Synology64\tv2\TV_Reality"
        };

        private string[] MovieFolders = {
            @"\\Plex-server\d\Movies"
        };

        private string DownloadPath = @"G:\NewsLeecher";
        private string ExtractionPath = @"e:\downloads";

        private FileFunctions fileFunctions = new FileFunctions();
        private FileExtractor fileExtractor = new FileExtractor();
        private StringFunctions stringFunctions = new StringFunctions();

        public Form1()
        {
            InitializeComponent();
            fileExtractor.StatusAdded += FileExtractor_StatusAdded;
            fileExtractor.StatusUpdated += FileExtractor_StatusUpdated;
        }

        private void FileExtractor_StatusAdded(object? sender, StatusEventArgs e)
        {
            AddStatus(e.StatusText);
        }

        private void FileExtractor_StatusUpdated(object? sender, StatusEventArgs e)
        {
            UpdateStatus(e.StatusText);
        }


        private void btnFix_Click(object sender, EventArgs e)
        {
            AddStatus("FIX: Renaming files...");
            foreach (string sFilename in Directory.GetFiles(txtPathname.Text))
            {
                if (sFilename.EndsWith(".mkv"))
                {
                    var sNewFilename = String.Concat(Path.GetDirectoryName(sFilename), "\\", FixFilename(Path.GetFileNameWithoutExtension(sFilename)), ".mkv");
                    if (fileFunctions.RenameFile(sFilename, sNewFilename))
                    {
                        AddStatus($"Renamed File: {sFilename} as {sNewFilename}");
                    }
                    else
                    {
                        AddStatus($"Error Renaming: {sFilename} - {fileFunctions.LastError}");
                    }
                }
            }
            AddStatus("FIX: Complete.");
        }

        void AddStatus(string s)
        {
            listBox1.Items.Add(s);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;
            listBox1.Refresh();
            System.Windows.Forms.Application.DoEvents();
        }

        void UpdateStatus(string s)
        {
            if (listBox1.Items.Count == 0) return;
            listBox1.Items[listBox1.Items.Count - 1] = s;
            listBox1.Refresh();
            System.Windows.Forms.Application.DoEvents();
        }

        string FixFilename(string Filename)
        {
            try
            {
                Filename = Filename.Replace(" ", ".");
                Filename = Filename.ToLower();
                Filename = Filename.Replace("repack.", "");
                // Better.Things.S02E10.Graduation.720p.AMZN.WEB-DL.DDP5.1.H.264-NTb
                Filename = stringFunctions.TrimAfter(Filename, "WEB-DL");
                Filename = stringFunctions.TrimAfter(Filename, "WEBRip");
                Filename = stringFunctions.TrimAfter(Filename, "WEB.X264");
                Filename = stringFunctions.TrimAfter(Filename, "WEB.H264");
                Filename = stringFunctions.UpperCaseWords(Filename);
                Filename = Filename.Replace("Ncis", "NCIS").Replace("La.", "LA.");
                return Filename;
            }
            catch
            {
                return "";
            }
        }

        private void btnPastePathname_Click(object sender, EventArgs e)
        {
            txtPathname.Text = Clipboard.GetText();
        }

        private void btnCopyFind_Click(object sender, EventArgs e)
        {
            txtFind.Text = Clipboard.GetText();
        }

        private void btnCopyReplace_Click(object sender, EventArgs e)
        {
            txtReplace.Text = Clipboard.GetText();
        }

        private void btnClearReplace_Click(object sender, EventArgs e)
        {
            txtReplace.Clear();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (string sFilename in Directory.GetFiles(txtPathname.Text))
            {
                string sNewFilename = String.Concat(Path.GetDirectoryName(sFilename), "\\", Path.GetFileName(sFilename).Replace(txtFind.Text, txtReplace.Text));
                if (fileFunctions.RenameFile(sFilename, sNewFilename))
                {
                    AddStatus($"Renamed File: {sFilename} as {sNewFilename}");
                }
                else
                {
                    AddStatus($"Error Renaming: {sFilename} - {fileFunctions.LastError}");
                }
            }
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear ();
            fileExtractor.ExtractArchives(DownloadPath, ExtractionPath);

        }

        
    }
}
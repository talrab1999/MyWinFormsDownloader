using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using Newtonsoft.Json;
using Microsoft.VisualBasic.Devices;  
using System.IO;

namespace FileDownloaderWizard
{
    public partial class MainForm : Form
    {
        private List<FileConfig> _configs;
        private int _currentIndex = 0;
        private readonly string ConfigUrl = "https://4qgz7zu7l5um367pzultcpbhmm0thhhg.lambda-url.us-west-2.on.aws/";
        private readonly string DownloadFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"FileDownloaderWizardDownloads");
        public MainForm()
        {
            InitializeComponent();
            Directory.CreateDirectory(DownloadFolder);
            InitializeConfigsAsync();
        }
        private async Task InitializeConfigsAsync()
        {
            //_configs = await FetchFileConfigsAsync(ConfigUrl);
            //_configs = _configs.OrderByDescending(f => f.Score).ToList();
            //_currentIndex = 0;
            //DisplayCurrentConfig();
            var all = await FetchFileConfigsAsync(ConfigUrl);
            var ci = new ComputerInfo();
            long ramMb = (long)ci.AvailablePhysicalMemory / 1024 / 1024;
            var driveRoot = Path.GetPathRoot(DownloadFolder);
            long diskMb = new DriveInfo(driveRoot).AvailableFreeSpace / 1024 / 1024;
            int osVer = Environment.OSVersion.Version.Major;

            _configs = all.Where(c =>
                      ramMb >= c.Ram &&   
                      diskMb >= c.Disk &&   
                      osVer >= c.Os)
                  .OrderByDescending(c => c.Score)  
                  .ToList();

            _currentIndex = 0;
            DisplayCurrentConfig();
        }
        private void DisplayCurrentConfig()
        {
            try
            {
                if (_configs == null || !_configs.Any()) return;
                var cfg = _configs[_currentIndex];
                titleLabel.Text = cfg.Title;
                pictureBox.Load(cfg.ImageUrl); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load: " + ex.Message);
            }
        }

        private async Task<List<FileConfig>> FetchFileConfigsAsync(string jsonUrl)
        {
            using var client = new HttpClient();
            var json = await client.GetStringAsync(jsonUrl);
            return JsonConvert.DeserializeObject<List<FileConfig>>(json);
        }

        private async void downloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                var cfg = _configs[_currentIndex];

                titleLabel.Text = cfg.Title;
                pictureBox.Load(cfg.ImageUrl);

                string fileName = Path.GetFileName(new Uri(cfg.FileUrl).LocalPath);
                string localPath = Path.Combine(DownloadFolder, fileName);

                if (File.Exists(localPath))
                {
                    MessageBox.Show("Already downloaded. Opening folder...");
                    Process.Start("explorer.exe", DownloadFolder);
                }
                else
                {
                    downloadButton.Enabled = false;
                    //using var http = new HttpClient();
                    //var data = await http.GetByteArrayAsync(cfg.FileUrl);
                    //File.WriteAllBytes(localPath, data);
                    downloadProgressBar.Value = 0;
                    using (var client = new WebClient())
                    {
                        client.DownloadProgressChanged += (s, ev) =>
                        {
                            downloadProgressBar.Value = ev.ProgressPercentage;
                        };

                        client.DownloadFileCompleted += (s, ev) =>
                        {
                            downloadButton.Enabled = true;
                        };

                        await client.DownloadFileTaskAsync(new Uri(cfg.FileUrl), localPath);
                    }

                    Process.Start(localPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load: " + ex.Message);
            }

        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            if (_configs == null || _configs.Count == 0) 
                return;
            _currentIndex = (_currentIndex + 1) % _configs.Count;
            DisplayCurrentConfig();
            downloadProgressBar.Value = 0;
        }
    }
}

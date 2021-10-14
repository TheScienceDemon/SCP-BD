using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows;

namespace SCP___The_Breach_Day_Launcher
{
    enum LauncherStates
    {
        SingleplayerReady,
        SingleplayerError,
        DownloadingSingleplayer,
        UpdatingSingleplayer,
        MultiplayerReady,
        MultiplayerError,
        DownloadingMultiplayer,
        UpdatingMultiplayer,
    }

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string rootPath;

        private string singleplayerVersionFile;
        private string singleplayerZip;
        private string singleplayerExe;

        private string multiplayerVersionFile;
        private string multiplayerZip;
        private string multiplayerExe;

        private LauncherStates _status;
        internal LauncherStates Status
        {
            get => _status;
            set
            {
                _status = value;
                switch (_status)
                {
                    case LauncherStates.SingleplayerReady:
                        SingleplayerButton.Content = "Play Singleplayer";
                        break;
                    case LauncherStates.SingleplayerError:
                        SingleplayerButton.Content = "Singleplayer download failed!";
                        break;
                    case LauncherStates.DownloadingSingleplayer:
                        SingleplayerButton.Content = "Downloading Singleplayer...";
                        break;
                    case LauncherStates.UpdatingSingleplayer:
                        SingleplayerButton.Content = "Updating Singleplayer...";
                        break;
                    case LauncherStates.MultiplayerReady:
                        MultiplayerButton.Content = "Play Multiplayer";
                        break;
                    case LauncherStates.MultiplayerError:
                        MultiplayerButton.Content = "Multiplayer download failed!";
                        break;
                    case LauncherStates.DownloadingMultiplayer:
                        MultiplayerButton.Content = "Downoading Multiplayer...";
                        break;
                    case LauncherStates.UpdatingMultiplayer:
                        MultiplayerButton.Content = "Updating Multiplayer...";
                        break;
                    default:
                        break;
                }
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            rootPath = Directory.GetCurrentDirectory();

            singleplayerVersionFile = Path.Combine(rootPath, "SingleplayerVersion.txt");
            singleplayerZip = Path.Combine(rootPath, "SingleplayerBuild.zip");
            singleplayerExe = Path.Combine(rootPath, "SingleplayerBuild", "SCP - The Breach Day.exe");

            multiplayerVersionFile = Path.Combine(rootPath, "MultiplayerVersion.txt");
            multiplayerZip = Path.Combine(rootPath, "MultiplayerBuild.zip");
            multiplayerExe = Path.Combine(rootPath, "MultiplayerBuild", "SCP - The Breach Day.exe");
        }

        private void CheckForSingleplayerUpdates()
        {
            if (File.Exists(singleplayerVersionFile))
            {
                Version localVersion = new Version(File.ReadAllText(singleplayerVersionFile));
                SingleplayerVersionText.Text = localVersion.ToString();

                try
                {
                    WebClient webClient = new WebClient();
                    Version onlineVersion = new Version(webClient.DownloadString("Version File Singleplayer Linmk"));

                    if (onlineVersion.IsDifferentThan(localVersion))
                    {
                        InstallSingleplayerFiles(true, onlineVersion);
                    }
                    else
                    {
                        Status = LauncherStates.SingleplayerReady;
                    }
                }
                catch (Exception ex)
                {
                    Status = LauncherStates.SingleplayerError;
                    MessageBox.Show($"Error while trying to download file: {ex}");
                }
            }
            else
            {
                InstallSingleplayerFiles(false, Version.zero);
            }
        }

        private void CheckForMultiplayerUpdates()
        {
            if (File.Exists(multiplayerVersionFile))
            {
                Version localVersion = new Version(File.ReadAllText(multiplayerVersionFile));
                MultiplayerVersionText.Text = localVersion.ToString();

                try
                {
                    WebClient webClient = new WebClient();
                    Version onlineVersion = new Version(webClient.DownloadString("Version File Multiplayer Linmk"));

                    if (onlineVersion.IsDifferentThan(localVersion))
                    {
                        InstallSingleplayerFiles(true, onlineVersion);
                    }
                    else
                    {
                        Status = LauncherStates.MultiplayerReady;
                    }
                }
                catch (Exception ex)
                {
                    Status = LauncherStates.MultiplayerError;
                    MessageBox.Show($"Error while trying to download file: {ex}");
                }
            }
            else
            {
                InstallMultiplayerFiles(false, Version.zero);
            }
        }

        private void InstallSingleplayerFiles(bool _isUpdate, Version _onlineVersion)
        {
            try
            {
                WebClient webClient = new WebClient();
                if (_isUpdate)
                    Status = LauncherStates.UpdatingSingleplayer;
                else
                {
                    Status = LauncherStates.DownloadingSingleplayer;
                    _onlineVersion = new Version(webClient.DownloadString("Version File Link Singleplayer"));
                }
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadSingleplayerCompleteCallback);
                webClient.DownloadFileAsync(new Uri("Game Zip Singleplayer link"), singleplayerZip, _onlineVersion);
            }
            catch (Exception ex)
            {
                Status = LauncherStates.SingleplayerError;
                MessageBox.Show($"Error while trying to download file: {ex}");
            }
        }

        private void InstallMultiplayerFiles(bool _isUpdate, Version _onlineVersion)
        {
            try
            {
                WebClient webClient = new WebClient();
                if (_isUpdate)
                    Status = LauncherStates.UpdatingMultiplayer;
                else
                {
                    Status = LauncherStates.DownloadingMultiplayer;
                    _onlineVersion = new Version(webClient.DownloadString("Version File Link Multiplayer"));
                }
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadMultiplayerCompleteCallback);
                webClient.DownloadFileAsync(new Uri("Game Zip Multiplayer link"), multiplayerZip, _onlineVersion);
            }
            catch (Exception ex)
            {
                Status = LauncherStates.MultiplayerError;
                MessageBox.Show($"Error while trying to download file: {ex}");
            }
        }

        private void DownloadSingleplayerCompleteCallback(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                string onlineVersion = ((Version)e.UserState).ToString();
                ZipFile.ExtractToDirectory(singleplayerZip, rootPath);
                File.Delete(singleplayerZip);

                File.WriteAllText(singleplayerVersionFile, onlineVersion);

                SingleplayerVersionText.Text = onlineVersion;
                Status = LauncherStates.SingleplayerReady;
            }
            catch (Exception ex)
            {
                Status = LauncherStates.SingleplayerError;
                MessageBox.Show($"Error when finishing download: {ex}");
            }
        }

        private void DownloadMultiplayerCompleteCallback(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                string onlineVersion = ((Version)e.UserState).ToString();
                ZipFile.ExtractToDirectory(multiplayerZip, rootPath);
                File.Delete(multiplayerZip);

                File.WriteAllText(multiplayerVersionFile, onlineVersion);

                MultiplayerVersionText.Text = onlineVersion;
                Status = LauncherStates.MultiplayerReady;
            }
            catch (Exception ex)
            {
                Status = LauncherStates.MultiplayerError;
                MessageBox.Show($"Error when finishing download: {ex}");
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            CheckForSingleplayerUpdates();
            CheckForMultiplayerUpdates();
        }

        private void SingleplayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(singleplayerExe) && (Status == LauncherStates.SingleplayerReady || Status == LauncherStates.MultiplayerReady))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(singleplayerExe);
                startInfo.WorkingDirectory = Path.Combine(rootPath, "SingleplayerBuild");
                Process.Start(startInfo);

                Close();
            }
            else if (Status == LauncherStates.SingleplayerError)
                CheckForSingleplayerUpdates();
        }

        private void MultiplayerButton_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(multiplayerExe) && (Status == LauncherStates.SingleplayerReady || Status == LauncherStates.MultiplayerReady))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(multiplayerExe);
                startInfo.WorkingDirectory = Path.Combine(rootPath, "MultiplayerBuild");
                Process.Start(startInfo);

                Close();
            }
            else if (Status == LauncherStates.MultiplayerError)
                CheckForMultiplayerUpdates();
        }
    }

    struct Version
    {
        internal static Version zero = new Version(0, 0, 0);

        private short major;
        private short minor;
        private short subMinor;

        internal Version(short _major, short _minor, short _subMinor)
        {
            major = _major;
            minor = _minor;
            subMinor = _subMinor;
        }

        internal Version(string _version)
        {
            string[] _versionStrings = _version.Split('.');

            if (_versionStrings.Length != 3)
            {
                major = 0;
                minor = 0;
                subMinor = 0;
                return;
            }

            major = short.Parse(_versionStrings[0]);
            minor = short.Parse(_versionStrings[1]);
            subMinor = short.Parse(_versionStrings[2]);
        }

        internal bool IsDifferentThan(Version _otherVersion)
        {
            if (major != _otherVersion.major) return true;
            else
            {
                if (minor != _otherVersion.minor) return true;
                else
                {
                    if (subMinor != _otherVersion.subMinor) return true;
                }
            }
            return false;
        }

        public override string ToString()
        {
            return $"{major}.{minor}.{subMinor}";
        }
    }
}

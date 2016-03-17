using CertifiTrack.Properties;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CertifiTrack;
using System.Windows.Media.Effects;
using MahApps.Metro.Controls;
using System.Threading;

namespace CertifiTrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<DeathCertificate> certificates = new List<DeathCertificate>();

        private void Window_Loaded(object sender, EventArgs e)
        {
            if (Settings.Default.statusFile == "")
            {
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == true)
                {
                    filePath.Text = open.FileName;
                    Settings.Default.statusFile = open.FileName;
                    Settings.Default.Save();
                }
            }
            else
            {
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == true)
                {
                    filePath.Text = open.FileName;
                    Settings.Default.statusFile = open.FileName;
                    Settings.Default.Save();
                }
            }

            certificates = ExcelData.GetCertificates(Settings.Default.statusFile);

            foreach (var cert in certificates)
            {
                Color locColor;
                Color bgColor;

                switch (cert._Location)
                {
                    case "S":
                        locColor = Colors.Red;
                        break;
                    case "V":
                        locColor = Colors.Green;
                        break;
                    case "W":
                        locColor = Colors.Black;
                        break;
                    default:
                        locColor = Colors.Black;
                        break;
                }

                if (cert._DateOfDeath.AddDays(21) <= DateTime.Now)
                {
                    bgColor = Colors.Yellow;
                }
                else
                {
                    bgColor = Colors.WhiteSmoke;
                }

                panel.Children.Add(new TextBlock
                {
                    Text = ExcelData.FormatDisplayString(cert._DateOfDeath.ToString("MM/dd/yyyy"), cert._Name, cert._Notes, cert._isApproved, cert._isElectronic, cert._Doctor),
                    Background = new SolidColorBrush(bgColor),
                    Foreground = new SolidColorBrush(locColor),
                    FontWeight = FontWeights.Bold,
                    FontSize = 24,
                    FontFamily = new FontFamily("Courier New"),
                    Margin = new Thickness(4, 4, 4, 2),
                    Height = 55,
                    Effect = new DropShadowEffect
                    {
                        Color = new Color { R = 128, B = 128, G = 128, A = 255 },
                        Direction = 315,
                        ShadowDepth = 2,
                        BlurRadius = 0.5
                    }
                });

                
            }
        }
    }
}

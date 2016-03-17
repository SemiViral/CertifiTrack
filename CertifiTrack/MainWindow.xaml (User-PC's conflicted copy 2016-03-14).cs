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

namespace CertifiTrack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static string filePath = @"D:\Dropbox\Coding\C#\CertifiTrack\CertifiTrack\assets\DC Status Updates.xlsx";
        static List<DeathCertificate> certificates = new List<DeathCertificate>();
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            certificates.Add(new DeathCertificate(new DateTime(2016, 1, 1), 2016001, "Smith, Mary", 'S', true, true, true, false, false, false, "Dr. David Shaw"));
            certificates.Add(new DeathCertificate(new DateTime(2016, 1, 3), 2016002, "Jones, Keith", 'W', true, true, true, false, false, false, "Dr. The Doctor"));

            foreach (DeathCertificate dc in certificates)
            {
                panel.Children.Add(new );
            }
        }
    }
}

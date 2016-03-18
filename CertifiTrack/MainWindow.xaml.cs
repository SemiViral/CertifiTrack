namespace CertifiTrack {
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
        }

        

            //foreach (var cert in Certificates)
            //{
            //    Color locColor;
            //    Color bgColor;

            //    switch (cert._Location)
            //    {
            //        case "S":
            //            locColor = Colors.Firebrick;
            //            break;
            //        case "V":
            //            locColor = Colors.CadetBlue;
            //            break;
            //        case "W":
            //            locColor = Colors.Black;
            //            break;
            //        default:
            //            locColor = Colors.Black;
            //            break;
            //    }

            //    bgColor = cert._DateOfDeath.AddDays(21) <= DateTime.Now ? Colors.Yellow : Colors.WhiteSmoke;

            //    panel.Children.Add(new TextBlock
            //    {
            //        Text = ExcelData.FormatDisplayString(cert._DateOfDeath.ToString("MM/dd/yyyy"), cert._Name, cert._Notes, cert._isApproved, cert._isElectronic, cert._Doctor),
            //        Background = new SolidColorBrush(bgColor),
            //        Foreground = new SolidColorBrush(locColor),
            //        FontWeight = FontWeights.Bold,
            //        FontSize = 24,
            //        FontFamily = new FontFamily("Courier New"),
            //        Margin = new Thickness(4, 4, 4, 2),
            //        Height = 55,
            //        Effect = new DropShadowEffect
            //        {
            //            Color = new Color { R = 128, B = 128, G = 128, A = 255 },
            //            Direction = 315,
            //            ShadowDepth = 2,
            //            BlurRadius = 0.5
            //        }
            //    });

            //}
    }
}
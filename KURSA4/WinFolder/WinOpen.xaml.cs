using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace KURSA4.WinFolder
{
    /// <summary>
    /// Логика взаимодействия для WinOpen.xaml
    /// </summary>
    public partial class WinOpen : Window
    {
        public WinOpen()
        {
            InitializeComponent();
        }

        private void MIStroitOtdelInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIStroitOtdelInstrument.Header;
        }

        private void WinOpen1_Loaded(object sender, RoutedEventArgs e)
        {
            MIStroitOtdelInstrument.Header = "Строительно-отделочный \n инструмент";
            LSelect.Content= string.Empty;
        }

        private void MISverlInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content= MISverlInstrument.Header;
        }

        private void MIRuchInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIRuchInstrument.Header;
        }

        private void MIMaliarInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIMaliarInstrument.Header;
        }

        private void MISlesarInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MISlesarInstrument.Header;
        }

        private void MISvarOborudovanie_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MISvarOborudovanie.Header;
        }

        private void MIRashodMaterial_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content= MIRashodMaterial.Header;
        }

        private void MIOsnastka_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIOsnastka.Header;
        }

        private void MIAbrazMaterial_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIAbrazMaterial.Header;
        }

        private void MISadInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content =MISadInstrument.Header;
        }

        private void MIZashita_Click(object sender, RoutedEventArgs e)
        {
           LSelect.Content =MIZashita.Header;
        }

        private void MIOther_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIOther.Header;
        }

        private void MIReshInstrument_Click(object sender, RoutedEventArgs e)
        {
            LSelect.Content = MIReshInstrument.Header;
        }
    }
}

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
    /// Логика взаимодействия для WinAbrazMaterial.xaml
    /// </summary>
    public partial class WinAbrazMaterial : Window
    {
        public WinAbrazMaterial()
        {
            InitializeComponent();
        }

        private void WinOpen1_Loaded(object sender, RoutedEventArgs e)
        {
            MIStroitOtdelInstrument.Header = "Строительно-отделочный \n инструмент";
        }

        private void MIKatalog_Click(object sender, RoutedEventArgs e)
        {
            WinOpen winOpen = new WinOpen();
            winOpen.ShowDialog();
            Close();
        }

        private void MISverlInstrument_Click(object sender, RoutedEventArgs e)
        {
            WinSverlInstrument winSverlInstrument = new WinSverlInstrument();
            winSverlInstrument.ShowDialog();
            Close();
        }

        private void MIStroitOtdelInstrument_Click(object sender, RoutedEventArgs e)
        {

          WinStroitOtdelInstrument winStroitOtdelInstrument = new WinStroitOtdelInstrument();
            winStroitOtdelInstrument.ShowDialog();
            Close();
        }

        private void MIReshInstrument_Click(object sender, RoutedEventArgs e)
        {
            WinReshInstrument winReshInstrument = new WinReshInstrument();
            winReshInstrument.ShowDialog();
            Close();
        }

        private void MIRuchInstrument_Click(object sender, RoutedEventArgs e)
        {
            WinRuchInstrument winRuchInstrument = new WinRuchInstrument();
            winRuchInstrument.ShowDialog();
            Close();
        }

        private void MIMaliarInstrument_Click(object sender, RoutedEventArgs e)
        {
            WinMaliarInstrument winMaliarInstrument = new WinMaliarInstrument();
            winMaliarInstrument.ShowDialog();
            Close();
        }

        private void MISlesarInstrument_Click(object sender, RoutedEventArgs e)
        {
            WinSlesarInstrument winSlesarInstrument = new WinSlesarInstrument();
            winSlesarInstrument.ShowDialog();
            Close();
        }

        private void MISvarOborudovanie_Click(object sender, RoutedEventArgs e)
        {
            WinSvarOborudovanie winSvarOborudovanie = new WinSvarOborudovanie();    
        }

        private void MIRashodMaterial_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MIOsnastka_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MISadInstrument_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MIZashita_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MIOther_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MIAbrazMaterial_Click(object sender, RoutedEventArgs e)
        {
            //
        }

        private void BCheck_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

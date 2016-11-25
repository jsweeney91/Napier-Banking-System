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

namespace NapierBankingSystem
{
    /// <summary>
    /// Interaction logic for QuarantinedViewer.xaml
    /// </summary>
    public partial class QuarantinedViewer : Window
    {
        public QuarantinedViewer()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(string s in MessageHolder.quarantined.Keys)
            {
                listBox.Items.Add(s);
            }
        }

        //shows the frequency of selected URL inside a label
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            frequencyLabel.Content = MessageHolder.quarantined[listBox.SelectedValue.ToString()];
        }
    }
}

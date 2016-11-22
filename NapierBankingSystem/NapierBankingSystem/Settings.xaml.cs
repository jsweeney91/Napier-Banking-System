using Microsoft.Win32;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.jsonFileTextbox.Text = Properties.Settings.Default.JSONFile;
            this.textwordsFileTextbox.Text = Properties.Settings.Default.Textwords;
        }

        private void jsonBrowse_Click(object sender, RoutedEventArgs e)
        {
            string path;
            Microsoft.Win32.OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog().HasValue)
            {
                path = file.FileName;
                jsonFileTextbox.Text = path;
                Properties.Settings.Default.JSONFile = path;
                Properties.Settings.Default.Save();
            }
        }

        private void textwordsBrowse_Click(object sender, RoutedEventArgs e)
        {
            string path;
            Microsoft.Win32.OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog().HasValue)
            {
                path = file.FileName;
                textwordsFileTextbox.Text = path;
                Properties.Settings.Default.Textwords = path;
                MessageHolder.getTextspeak();
                Properties.Settings.Default.Save();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window tw = new TextwordsEdit();
            tw.Show();
        }
    }
}

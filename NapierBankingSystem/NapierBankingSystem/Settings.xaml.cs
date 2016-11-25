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
        public static bool isOpen = false;

        public Settings()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.jsonFileTextbox.Text = Properties.Settings.Default.JSONFile;
            this.textwordsFileTextbox.Text = Properties.Settings.Default.Textwords;
            this.quarantinedTb.Text = Properties.Settings.Default.Quarantined;
        }

        /// <summary>
        /// used for changing the JSON path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                MessageHolder.readMessages();
            }
        }
        /// <summary>
        /// used for changing textwords file path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// used for showing textwords editor window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Window tw = new TextwordsEdit();
            tw.Show();
        }
        /// <summary>
        /// used for changing quarantined file path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quarantinedButton_Click(object sender, RoutedEventArgs e)
        {
            string path;
            Microsoft.Win32.OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog().HasValue)
            {
                path = file.FileName;
                quarantinedTb.Text = path;
                Properties.Settings.Default.Quarantined = path;
                MessageHolder.getQuarantinedItems();
                Properties.Settings.Default.Save();
            }
        }
        /// <summary>
        /// shows the quarantined items in new window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewQuarantinedbutton_Click(object sender, RoutedEventArgs e)
        {
            Window win = new QuarantinedViewer();
            win.Show();
        }
    }
}

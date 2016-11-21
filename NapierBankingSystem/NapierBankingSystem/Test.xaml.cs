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
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            testHashtags();
        }
        public static void testHashtags()
        {
            foreach (string k in MessageHolder.mentions.Keys)
            {
                MessageBox.Show(k);
                foreach (string u in MessageHolder.mentions[k])
                {
                    MessageBox.Show(MessageHolder.messages[u].messageBody);
                }
            }
        }

    }
}

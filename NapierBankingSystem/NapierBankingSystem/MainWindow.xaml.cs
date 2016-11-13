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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NapierBankingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JSON js = new JSON();
        Dictionary<string, Message> messages;

        public MainWindow()
        {
            InitializeComponent();

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            messages = new Dictionary<string, Message>();
           
        }

        private void button_Click1(object sender, RoutedEventArgs e)
        {
       
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Window win = new MessageViewer();
            win.Show();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Window win = new SendMessage();
            win.Show();
        }
    }
}

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
    /// Interaction logic for SendMessage.xaml
    /// </summary>
    public partial class SendMessage : Window
    {
        public SendMessage()
        {
            InitializeComponent();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {     
            ComboBoxItem itm = (ComboBoxItem)mailTypeSelection.SelectedValue;
            MessageBox.Show(itm.Content.ToString());
            if (itm.Content.ToString() == "Email")
            {
                Page pg = new SendEmail();
                contentFrame.Content = pg;     
            }
            else if(itm.Content.ToString() == "SMS")
            {
                Page pg = new SendSMS();
                contentFrame.Content = pg;
            }
            else if (itm.Content.ToString() == "Tweet")
            {
                Page pg = new SendTweet();
                contentFrame.Content = pg;
            }
        }
    }
}

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
        private double originalHeight;

        public SendMessage()
        {
            InitializeComponent();
            this.originalHeight = this.Height;
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {     
            ComboBoxItem itm = (ComboBoxItem)mailTypeSelection.SelectedValue;
            Page pg = new Page();

            if (itm.Content.ToString() == "Email")
            {
                pg = new SendEmail();          
            }
            else if(itm.Content.ToString() == "SMS")
            {                
                pg = new SendSMS();
            }
            else if (itm.Content.ToString() == "Tweet")
            {
                pg = new SendTweet();
            }
            contentFrame.Height = pg.Height;
            contentFrame.Content = pg;
        }
    }
}

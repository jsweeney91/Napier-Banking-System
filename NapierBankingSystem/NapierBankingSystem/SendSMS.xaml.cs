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
    /// Interaction logic for SendSMS.xaml
    /// </summary>
    public partial class SendSMS : Page
    {
        public SendSMS()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            if (validateInput())
            {
                string currentID = (MessageHolder.currentSMSID + 1).ToString();
                if (currentID.Length < 9)
                {
                    string zeros = String.Concat(Enumerable.Repeat("0", 9 - currentID.Length));
                    currentID = zeros + currentID;

                }
                currentID = "S" + currentID;

                SMS sms = new SMS(currentID +" "+ phoneNoTextbox.Text + " " + messageTextbox.Text);
                MessageHolder.currentSMSID++;
                MessageHolder.addMessage(currentID, sms);
            }
        }
        public bool validateInput()
        {
            bool canAdd = true;
            errorLbl.Content = "";
            string phoneNo = phoneNoTextbox.Text.Replace(" ", "");
            phoneNo = phoneNoTextbox.Text.Replace("+", "");
            long n;
            bool isNumeric = long.TryParse(phoneNo, out n);

            if (!isNumeric || string.IsNullOrEmpty(phoneNo))
            {                
                errorLbl.Content += "Please enter a valid number(International format) "+Environment.NewLine;
                canAdd = false;
            }else if (phoneNo.Length != 12)
            {
                errorLbl.Content += "Please enter a valid number(International format) "+Environment.NewLine;
                canAdd = false;
            }
            if (messageTextbox.Text.Length >= 140 )
            {
                errorLbl.Content += "140 Character maximum for message text "+Environment.NewLine;
                canAdd = false;
            }else if (string.IsNullOrEmpty(messageTextbox.Text))
            {
                errorLbl.Content += "Please enter a message "+Environment.NewLine;
                canAdd = false;
            }

            return canAdd;
        }

    }
}

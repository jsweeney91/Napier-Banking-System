using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SendEmail.xaml
    /// </summary>
    public partial class SendEmail : Page
    {
        public SendEmail()
        {
            InitializeComponent();
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
               if (validateInput())
            {
                string currentID = (MessageHolder.currentEmailID + 1).ToString();
                if (currentID.Length < 9)
                {
                    string zeros = String.Concat(Enumerable.Repeat("0", 9 - currentID.Length));
                    currentID = zeros + currentID;

                }
                currentID = "E" + currentID;

                Email email = new Email(currentID + " " + emailTextbox.Text + " " + subjectTextbox.Text+ " " +messageTextbox.Text);
                MessageHolder.currentEmailID++;
                MessageHolder.addMessage(currentID, email);
            }

        }

        private bool validateInput()
        {
            string pattern = @"[!#$%&'\\*\\+\\-\\/\\=\\?\\^\\_`\\{\\|\\}\\~\\+a-zA-Z0-9\\.]+@.*?[a-zA-Z0-9\\.]+";
            Regex re = new Regex(pattern);
            Match m = Regex.Match(emailTextbox.Text, pattern);
            bool canAdd = true;

            errorLbl.Content = "";

            if (!m.Success)
            {
                errorLbl.Content += "Invalid email address " + Environment.NewLine;
                canAdd = false;
            }

           
            
            if (subjectTextbox.Text.Length >= 20 ) 
            {
                errorLbl.Content += "Subject must be less than 20 characters "+Environment.NewLine;
                canAdd = false;
            }else if (String.IsNullOrEmpty(subjectTextbox.Text))
            {
                errorLbl.Content += "Please enter a subject "+Environment.NewLine;
                canAdd = false;
            }
            else if (subjectTextbox.Text.Length < 20)
            {
               subjectTextbox.Text += String.Concat(Enumerable.Repeat(" ", 20 - subjectTextbox.Text.Length));
            }
            if (messageTextbox.Text.Length >= 1028)
            {
                errorLbl.Content += "Message too long (1028 characters max) "+Environment.NewLine;
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

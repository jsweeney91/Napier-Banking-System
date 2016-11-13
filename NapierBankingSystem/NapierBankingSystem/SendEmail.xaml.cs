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
            validateInput();

        }
        private bool validateInput()
        {
            errorLbl.Content = "";
            bool canAdd = true;
            if (subjectTextbox.Text.Length >= 20 ) 
            {
                errorLbl.Content += "Subject must be less than 20 characters \n";
                canAdd = false;
            }else if (String.IsNullOrEmpty(subjectTextbox.Text))
            {
                errorLbl.Content += "Please enter a subject \n";
                canAdd = false;
            }
            if(messageTextbox.Text.Length >= 1028)
            {
                errorLbl.Content += "Message too long (1028 characters max) \n";
                canAdd = false;
            }else if (string.IsNullOrEmpty(messageTextbox.Text))
            {
                errorLbl.Content += "Please enter a message \n";
                canAdd = false;
            }
            return canAdd;
        }
    }
}

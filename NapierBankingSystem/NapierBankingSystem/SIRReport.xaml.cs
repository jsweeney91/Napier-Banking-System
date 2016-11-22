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
    /// Interaction logic for SIRReport.xaml
    /// </summary>
    public partial class SIRReport : Page
    {
        public SIRReport()
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

                ComboBoxItem cmb = (ComboBoxItem)incidentTypeCombo.SelectedItem;
                string subject = "SIR "+ System.DateTime.Now.ToString("dd/MM/yy");                   
                string messageBody = " Sort Code: " + sortcode1Tb.Text + "-" + sortCode2tb.Text + "-" + sortCode3tb.Text + " \nNature of Incident: " + cmb.Content + " " +messageTextbox.Text;              
                
                subject += String.Concat(Enumerable.Repeat(" ", 20 - subject.Length));

                SIR sir = new SIR(currentID + " " + emailTextbox.Text + " " + subject + messageBody);
                MessageHolder.currentEmailID++;
                MessageHolder.addMessage(currentID, sir);
            }
        }

        private bool validateInput()
        {
            errorLbl.Content = "";
            bool canAdd = true;
            int sc1,sc2,sc3;
            
            bool ty = int.TryParse(sortcode1Tb.Text, out sc1);
            if (ty)
            {

                ty = int.TryParse(sortCode2tb.Text, out sc2);
                if (ty)
                {
                    ty = int.TryParse(sortCode3tb.Text, out sc3);
                }
            }else
            {
                MessageBox.Show(sc1.ToString());                
            }

            if (!ty)
            {
                errorLbl.Content += "Enter a valid sort code \n";
            }

            if(sortcode1Tb.Text.Length!=2 || sortCode2tb.Text.Length!=2 || sortCode3tb.Text.Length!=2)
            {
                canAdd = false;
            }
            
            ComboBoxItem cmb = (ComboBoxItem)incidentTypeCombo.SelectedItem;

            if (cmb == null)
            {
                canAdd = false;
                errorLbl.Content += "Please select an incident type \n";
            }

            return canAdd;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(string it in MessageHolder.incidentTypes)
            {
                ComboBoxItem cmb = new ComboBoxItem();
                cmb.Content = it;
                incidentTypeCombo.Items.Add(cmb);
            }
          
        }
    }
}

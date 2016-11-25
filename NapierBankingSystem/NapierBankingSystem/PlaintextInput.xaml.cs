using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace NapierBankingSystem
{
    /// <summary>
    /// Interaction logic for PlaintextInput.xaml
    /// </summary>
    public partial class PlaintextInput : Window
    {
        public PlaintextInput()
        {
            InitializeComponent();
        }

        //userd to import text files into the textbox
        private void importButton_Click(object sender, RoutedEventArgs e)
        {
            string contents = "";
            Microsoft.Win32.OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog().HasValue)
            {
                if (!String.IsNullOrEmpty(file.FileName))
                {
                    contents += System.IO.File.ReadAllText(file.FileName);
                }
            }
            plainTexttextbox.Text = contents;
        }

        ///submit values inside the textbox, can be bulk input
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            //check for the all the messages by looking for message id format
            string pattern = @"[SET]\d{9}";
            MatchCollection matches = Regex.Matches(plainTexttextbox.Text, pattern);
            int[] indexes = new int[matches.Count];
            int count = 0;
            string[] ids = new string[matches.Count];
            try
            {
                //get the index of all the matches
                foreach (Match m in matches)
                {
                    if (ids.Contains(m.Groups[0].ToString()))
                    {
                        throw new Exception();    
                    }
                    else
                    {
                        ids[count] = m.Groups[0].ToString();
                    }

                    indexes[count] = plainTexttextbox.Text.IndexOf(m.Groups[0].ToString());
                    count++;
                }
                //goes through the indexes of the id's and converts them to messages
                for (int i = 1; i < count; i++)
                {
                    bool hasOverwritten = true;
                    MessageProcessor proc = new MessageProcessor();
                    Message msg = proc.convertMessage(plainTexttextbox.Text.Substring(indexes[i - 1], indexes[i] - indexes[i - 1]));
                    msg.messageBody = msg.messageBody.Replace("\\n", Environment.NewLine);
                    if (MessageHolder.messages.ContainsKey(msg.messageID)) //checks if id already exists inside the dictionary
                    {
                        //prompt user to overwrite existing ID values
                        MessageBoxResult overwrite = MessageBox.Show(msg.messageID + " already exists, replace?", "Overwrite value?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (overwrite == MessageBoxResult.Yes)
                        {
                            MessageHolder.messages[msg.messageID] = msg;
                            MessageHolder.refresher.numberOfMessages -= 1;
                        }
                        else
                        {
                            hasOverwritten = false;
                        }
                    }
                    else
                    {
                        MessageHolder.addMessage(msg.messageID,msg);
                    }

                    //will be true if existing id wasnt found or if user accepts the overwrite prompt
                    if (hasOverwritten)
                    {
                        Window vm = new ViewMessage(msg.messageID);
                        vm.ShowDialog();
                    }
                   

                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Duplicate keys found in text");
            }

        }


    }
}

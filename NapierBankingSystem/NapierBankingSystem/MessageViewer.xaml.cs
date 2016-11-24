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
    /// Interaction logic for MessageViewer.xaml
    /// </summary>
    public partial class MessageViewer : Window
    {
        

        public MessageViewer()
        {
            InitializeComponent();
        }

        private void refreshData(string typeIn)
        {
            if (typeIn == "all")
            {
                messageListBox.Items.Clear();
                foreach (Message m in MessageHolder.messages.Values)
                {
                    string messageType = m.GetType().ToString();
                    string[] splitval = messageType.Split('.');
                    MessageProcessor proc = m.returnData();
                    string body = proc.body;                 
                    messageListBox.Items.Add(createGrid(proc.header, body, splitval[splitval.Length - 1]));
                }
            }
            else
            {
                messageListBox.Items.Clear();
                foreach (Message m in MessageHolder.messages.Values)
                {
                    string messageType = m.GetType().ToString();
                    string[] splitval = messageType.Split('.');
                    MessageProcessor proc = m.returnData();
                    string body = proc.body;

                    if (splitval[splitval.Length - 1] == typeIn)
                    {      
                        messageListBox.Items.Add(createGrid(proc.header, body, splitval[splitval.Length - 1]));
                    }
                }
            }
        }

        private Grid createGrid(string header,string body,string messageType)
        {
            Grid myGrid = new Grid();
            myGrid.Width = messageListBox.Width;
            myGrid.Height = 50;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.VerticalAlignment = VerticalAlignment.Top;
            myGrid.ShowGridLines = true;

            // Define the Columns
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();
            ColumnDefinition colDef3 = new ColumnDefinition();

            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);
            myGrid.ColumnDefinitions.Add(colDef3);

            // Define the Rows
            RowDefinition rowDef1 = new RowDefinition();
            myGrid.RowDefinitions.Add(rowDef1);

            // Add the second text cell to the Grid
            Label txt1 = new Label();
            txt1.Content = header;
            txt1.FontSize = 8;
            Grid.SetRow(txt1, 0);
            Grid.SetColumn(txt1, 0);

            // Add the third text cell to the Grid
            Label txt2 = new Label();
            txt2.Content = body;
            txt2.FontSize = 8;
            Grid.SetRow(txt2, 0);
            Grid.SetColumn(txt2, 1);

            // Add the third text cell to the Grid
            Label txt3 = new Label();
            txt3.Content = messageType;
            txt3.FontSize = 8;
            Grid.SetRow(txt3, 0);
            Grid.SetColumn(txt3, 2);

            myGrid.Children.Add(txt1);
            myGrid.Children.Add(txt2);
            myGrid.Children.Add(txt3);

            return myGrid;
        }

        private void messageListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                String msg = "";
                Grid message = (Grid)messageListBox.SelectedValue;
                msg += ((Label)message.Children[0]).Content;
                if (MessageHolder.messages[msg].seen == false)
                {
                    MessageHolder.messages[msg].seen = true;
                    MessageHolder.refresher.addNewSeen();
                }

                Window messV = new ViewMessage(msg);
                messV.Show();
            }
            catch(NullReferenceException ex)
            {
                //clears the selected item in the listbox
            }              

        }

        private void messageListBox_Loaded(object sender, RoutedEventArgs e)
        {
            refreshData("all");
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            messageListBox.SelectedItem = null;
            ListBoxItem itm = (ListBoxItem)comboBox.SelectedValue;
            if(itm.Content.ToString()== "All messages")
            {
                refreshData("all");
            }
            else if (itm.Content.ToString() == "Tweets")
            {
                refreshData("Tweet");
            }
            else if (itm.Content.ToString() == "Standard Emails")
            {
                refreshData("Email");
            }
            else if (itm.Content.ToString() == "SIR Emails")
            {
                refreshData("SIR");
            }
            else if (itm.Content.ToString() == "SMS messages")
            {
                refreshData("SMS");
            }
        }
    }
}

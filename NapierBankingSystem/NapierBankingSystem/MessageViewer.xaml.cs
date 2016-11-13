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
        private void refreshData()
        {
            messageListBox.Items.Clear();
            foreach (Message m in MessageHolder.messages.Values)
            {
                string messageType = m.GetType().ToString();
                string[] splitval = messageType.Split('.');
                MessageProcessor proc = m.returnData();
                messageListBox.Items.Add(createGrid(proc.header, proc.body, splitval[splitval.Length - 1]));
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageHolder.readMessages();
            refreshData();
           
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
            String msg = "";
            Grid message = (Grid)messageListBox.SelectedValue;
            foreach(UIElement elm in message.Children){
                
                Label blk = (Label)elm;
                msg += blk.Content;
            }

            MessageBox.Show(msg);
        }

        private void messageListBox_Loaded(object sender, RoutedEventArgs e)
        {
            refreshData();
        }
    }
}

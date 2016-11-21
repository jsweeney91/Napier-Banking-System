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
    /// Interaction logic for NotificationPanel.xaml
    /// </summary>
    public partial class NotificationPanel : Window
    {
        public NotificationPanel()
        {
            InitializeComponent();
            loadNotifications();
        }
        private void loadNotifications()
        {
            notificationListBox.Items.Clear();
            foreach (Message m in MessageHolder.messages.Values)
            {
                if (!m.seen)
                {
                    string messageType = m.GetType().ToString();
                    string[] splitval = messageType.Split('.');
                    notificationListBox.Items.Add(createGrid(m.sender, "New " + splitval[splitval.Length - 1]));
                }
            }
        }
        private Grid createGrid(string header, string messageType)
        {
            Grid myGrid = new Grid();
            myGrid.Width = notificationListBox.Width;
            myGrid.Height = 50;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.VerticalAlignment = VerticalAlignment.Top;

            // Define the Columns
            ColumnDefinition colDef1 = new ColumnDefinition();
            ColumnDefinition colDef2 = new ColumnDefinition();

            myGrid.ColumnDefinitions.Add(colDef1);
            myGrid.ColumnDefinitions.Add(colDef2);

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
            txt2.Content = messageType;
            txt2.FontSize = 8;
            Grid.SetRow(txt2, 0);
            Grid.SetColumn(txt2, 1);

            myGrid.Children.Add(txt1);
            myGrid.Children.Add(txt2);

            return myGrid;
        }
    }
}

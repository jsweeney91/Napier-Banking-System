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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,Observer
    {
        JSON js = new JSON();
        Dictionary<string, Message> messages;

        public MainWindow()
        {
            InitializeComponent();
            MessageHolder.readMessages();
            MessageHolder.refresher.addObserver(this);
            
        }

        private void viewMessagesButton_Click(object sender, RoutedEventArgs e)
        {
            Window win = new MessageViewer();
            win.Show();
        }
        public void receiveNotification()
        {
            this.Dispatcher.Invoke(() =>
            {
                this.notificationFeedbackLbl.Content = (MessageHolder.messages.Count - MessageHolder.refresher.numberOfMessages).ToString();
            });
            
        }

        private void addMessageButton_Click(object sender, RoutedEventArgs e)
        {
            Window win = new SendMessage();
            win.Show();
        }
        
        private void notificationFeedbackLbl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window notificationPanel = new NotificationPanel();
            notificationPanel.Show();
        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            Window tet = new Test();
            tet.Show();
        }
    }
}

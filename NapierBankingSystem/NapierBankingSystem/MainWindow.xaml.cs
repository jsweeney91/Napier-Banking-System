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
        public MainWindow()
        {
            InitializeComponent();

            //populate the messageholder 
            MessageHolder.readMessages();

            //register for notifications of new messages received
            MessageHolder.refresher.addObserver(this);
            
        }

        private void viewMessagesButton_Click(object sender, RoutedEventArgs e)
        {
            Window win = new MessageViewer();
            win.Show();
        }

        //this is used to update the notification pane when messages are received 
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
        
        //Opens the notification window when notification pane is clicked
        private void notificationFeedbackLbl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {            
            Window notificationPanel = new NotificationPanel();
            MessageHolder.refresher.numberOfMessages = MessageHolder.messages.Count; //reset the number of notification as the user will see them
            notificationFeedbackLbl.Content = (MessageHolder.refresher.numberOfMessages - MessageHolder.messages.Count).ToString(); //update label
            notificationPanel.Show();
        }

        private void button_Copy2_Click(object sender, RoutedEventArgs e)
        {
            Window set = new Settings();
            set.Show();
        }

        private void addMessagesButton_Click(object sender, RoutedEventArgs e)
        {
            Window set = new PlaintextInput();
            set.Show();
        }
    }
}

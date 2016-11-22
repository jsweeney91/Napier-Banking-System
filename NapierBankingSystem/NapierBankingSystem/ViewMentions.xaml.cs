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
    /// Interaction logic for ViewMentions.xaml
    /// </summary>
    public partial class ViewMentions : Page
    {
        public ViewMentions(string hashtag)
        {
            InitializeComponent();
            populatePage(hashtag);
        }
        public void populatePage(string hashtag)
        {
            this.mentionLabel.Content = hashtag;
            
            foreach (string m in MessageHolder.mentions[hashtag])
            {
                messagesListbox.Items.Add(MessageHolder.messages[m].messageID);
            }
            if (hashtag.StartsWith("@"))
            {
                foreach(string m in MessageHolder.messages.Keys)
                {
                    if (MessageHolder.messages[m].sender == hashtag)
                    {
                        messagesListbox.Items.Add(MessageHolder.messages[m].messageID);
                    }
                }
            }
            
            Window win = new ViewMessage(this);
            win.Show();
        }

        private void messagesListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewMessage msg = new ViewMessage(messagesListbox.SelectedValue.ToString());
            msg.Show();
        }
    }
}

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
        /// <summary>
        /// finds all the messages with the hashtag provided/mention of another user
        /// </summary>
        /// <param name="hashtag">the hashtag/mention to find</param>
        public ViewMentions(string hashtag)
        {
            InitializeComponent();
            populatePage(hashtag);
        }
        /// <summary>
        /// populate the listbox with message contatining the hashtag
        /// </summary>
        /// <param name="hashtag">hashtag to check</param>
        public void populatePage(string hashtag)
        {
            this.mentionLabel.Content = hashtag; //show the user the hashtag being displayed
            
            foreach (string m in MessageHolder.mentions[hashtag])
            {
                messagesListbox.Items.Add(MessageHolder.messages[m].messageID);
            }
            if (hashtag.StartsWith("@")) //if it's a mention also show posts by the user being mentioned
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

        //shows the message selected in a new window
        private void messagesListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewMessage msg = new ViewMessage(messagesListbox.SelectedValue.ToString());
            msg.Show();
        }
    }
}

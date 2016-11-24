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
    /// Interaction logic for ViewTweet.xaml
    /// </summary>
    public partial class ViewTweet : Page
    {
        public ViewTweet(Tweet t)
        {
            InitializeComponent();
            assignData(t);
        }
        public void assignData(Tweet t)
        {
            senderLbl.Content = t.sender;
            messageBodyTb.Text = getAbbreviations(t.messageBody);
            getHashTags(t.messageID);
            getTrending();
        }

        public String getAbbreviations(string body)
        {
            string[] message = body.Split(' ');
            List<int> toChange = new List<int>();
            for (int i = 0; i < message.Length;i++)
            {
                if (MessageHolder.textspeak.ContainsKey(message[i]))
                {
                    toChange.Add(i);
                }
            }
            foreach(int c in toChange)
            {
                message[c] = message[c] + "<<"+MessageHolder.textspeak[message[c]]+">>";
            }
            return String.Join(" ", message);
        }

        public void getHashTags(string userId)
        {
            foreach(string h in MessageHolder.mentions.Keys)
            {
                if (MessageHolder.mentions[h].Contains(userId))
                {
                    hashtagListbox.Items.Add(h);
                }
            }
        }
        private void getTrending()
        {
            var values = from pair in MessageHolder.mentions orderby pair.Value.Count descending select pair.Key.ToString();
            foreach(string v in values)
            {
                if (v.StartsWith("#"))
                {
                    trendingListbox.Items.Add(v);
                }
            }
        }

        private void hashtagListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Page mentions = new ViewMentions(hashtagListbox.SelectedValue.ToString());           
        }

        private void trendingListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Page mentions = new ViewMentions(trendingListbox.SelectedValue.ToString());
        }
    }
}

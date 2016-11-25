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
        /// <summary>
        /// populate page with tweet data 
        /// </summary>
        /// <param name="t">the tweet to pull data from </param>
        public ViewTweet(Tweet t)
        {
            InitializeComponent();
            assignData(t);
        }

        /// <summary>
        /// populates the relevant elements with the tweet data
        /// </summary>
        /// <param name="t"></param>
        public void assignData(Tweet t)
        {
            senderLbl.Content = t.sender;
            messageBodyTb.Text = getAbbreviations(t.messageBody);
            getHashTags(t.messageID);
            getTrending();
        }

        /// <summary>
        /// find the abbreviations inside the tweet and translate them
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public String getAbbreviations(string body)
        {
            string[] message = body.Split(' ');
            List<int> toChange = new List<int>(); //holds all the indexes of the values to be changed
            //cant change values inside the loop
            for (int i = 0; i < message.Length;i++)
            {
                if (MessageHolder.textspeak.ContainsKey(message[i]))
                {
                    toChange.Add(i);
                }
            }
            //update the values at the indexes
            foreach(int c in toChange)
            {
                message[c] = message[c] + "<<"+MessageHolder.textspeak[message[c]]+">>";
            }
            return String.Join(" ", message);
        }

        /// <summary>
        /// find the hashtags in the message by checking the hashtag dictionary
        /// </summary>
        /// <param name="userId">the message id to look for in the dictionary</param>
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

        /// <summary>
        /// finds all the hashtags used and sorts them in order of frequency
        /// </summary>
        private void getTrending()
        {
            //sort values
            var values = from pair in MessageHolder.mentions orderby pair.Value.Count descending select pair.Key.ToString();
            foreach(string v in values)
            {
                if (v.StartsWith("#")) //dont want to also add "mentions" (@ symbol) 
                {
                    trendingListbox.Items.Add(v);
                }
            }
        }
        /// <summary>
        /// new hashtag selected, show mentions window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hashtagListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Page mentions = new ViewMentions(hashtagListbox.SelectedValue.ToString());           
        }

        /// <summary>
        /// hashtag selected in trending listbox, show mentions window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trendingListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Page mentions = new ViewMentions(trendingListbox.SelectedValue.ToString());
        }
    }
}

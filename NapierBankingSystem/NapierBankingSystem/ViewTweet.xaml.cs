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
            string labeltext = "";
            labeltext += t.sender + "\n";
            labeltext += t.messageBody;
            tweetContentLabel.Content = labeltext;
            getHashTags(t.messageID);
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

        private void hashtagListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Page mentions = new ViewMentions(hashtagListbox.SelectedValue.ToString());           
        }
    }
}

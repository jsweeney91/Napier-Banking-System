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
    /// Interaction logic for ViewMessage.xaml
    /// </summary>
    public partial class ViewMessage : Window
    {
        public ViewMessage(string M)
        {
           InitializeComponent();
           getFrameData(M);     
        }

        public ViewMessage(Page pageIN)
        {
            InitializeComponent();
            this.Content = pageIN;
        }

        public void getFrameData(string m)
        {
            if (m.StartsWith("T"))
            {
                Page tweet = new ViewTweet((Tweet) MessageHolder.messages[m]);
                frame.Content = tweet;
            }else
            {
                Page gen = new GenericMessageReader(MessageHolder.messages[m]);
                frame.Content = gen;
            }
        }
       
    }
}

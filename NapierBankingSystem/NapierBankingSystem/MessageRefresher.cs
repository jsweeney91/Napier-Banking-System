using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;

namespace NapierBankingSystem
{
    public class MessageRefresher : Observable
    {
        public List<Observer> observers{ get; set; }
        public int numberOfMessages { get; set; }
        private static MessageRefresher instance;

        private MessageRefresher()
        {
            this.observers = new List<Observer>();
            refreshMessages();
        }

        public static MessageRefresher getInstance()
        {
            if (instance == null)
            {
                instance = new MessageRefresher();
            }
            return instance;
        }

        private void refreshMessages()
        {
            Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 5000;
            aTimer.Enabled = true;
        }

        public void addObserver(Observer win)
        {
            observers.Add(win);
        }

        private void notifyObservers()
        {
            MessageBox.Show("hi");
            foreach (Observer o in observers)
            {
                o.receiveNotification();
            }
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (MessageHolder.messages.Count > numberOfMessages)
            {
                notifyObservers();
            }
        }
    }
}

﻿using System;
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
    /// Interaction logic for TextwordsEdit.xaml
    /// </summary>
    public partial class TextwordsEdit : Window
    {
        public TextwordsEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// load initial values to listboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refreshListbox();
        }
        /// <summary>
        /// populates the listbox values 
        /// </summary>
        private void refreshListbox()
        {
            valueTextbox.Text = "";

            abbreviationListbox.Items.Clear();
            foreach (string s in MessageHolder.textspeak.Keys)
            {
                abbreviationListbox.Items.Add(s);
            }
        }

        /// <summary>
        /// shows the definition of a selected item inside the valueTextbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abbreviationListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                valueTextbox.Text = MessageHolder.textspeak[abbreviationListbox.SelectedValue.ToString()];
            }
            catch (Exception ex)
            {
                //used to clear selection when refreshing listbox
            }
        }

        /// <summary>
        /// updates the CSV file if a value is being changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Change "+ MessageHolder.textspeak[abbreviationListbox.SelectedValue.ToString()] +" to "+valueTextbox.Text, "Change value?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MessageHolder.textspeak[abbreviationListbox.SelectedValue.ToString()] = valueTextbox.Text;
                MessageHolder.updateTextspeak();//update the values being held by the applicaiton
            }
            else
            {
                valueTextbox.Text = MessageHolder.textspeak[abbreviationListbox.SelectedValue.ToString()]; //reset textbox value
            }
        }

        /// <summary>
        /// used to remove values from dictionary and csv file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
             MessageBoxResult result = MessageBox.Show("Delete "+abbreviationListbox.SelectedValue.ToString()+"? ", "Delete value?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                MessageHolder.textspeak.Remove(abbreviationListbox.SelectedValue.ToString());
                MessageHolder.updateTextspeak();
                refreshListbox();
            }            
        }

        /// <summary>
        /// adds new textwords to the csv file and dictionary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addTextword_Click(object sender, RoutedEventArgs e)
        {
            bool shouldRefresh = false;
            MessageBoxResult result = MessageBox.Show("Add "+ shorthandTb.Text+": "+longtextwordTb.Text +"? ", "Add value?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                if (MessageHolder.textspeak.ContainsKey(shorthandTb.Text))
                {
                    MessageBoxResult overwrite = MessageBox.Show(shorthandTb.Text+" already exists("+MessageHolder.textspeak[shorthandTb.Text]+"), replace?", "Overwrite value?", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (overwrite == MessageBoxResult.Yes)
                    {
                        MessageHolder.textspeak[shorthandTb.Text] = longtextwordTb.Text;
                        MessageHolder.updateTextspeak();
                        shouldRefresh = true;
                    }
                    else
                    {

                    }
                }
                else
                {
                    MessageHolder.textspeak.Add(shorthandTb.Text, longtextwordTb.Text);
                    MessageHolder.updateTextspeak();
                    shouldRefresh = true;
                }               
            }
            if (shouldRefresh)
            {
                refreshListbox();
            }
        }
    }
}

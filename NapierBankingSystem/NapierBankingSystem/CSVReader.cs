﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NapierBankingSystem
{
    public class CSVReader
    {
        //disables the message box when the unit tests are being ran
        public bool isTesting { get; set; } = false;


        // used to read in the .csv files, can only work with two columns
        /// <param name="fileName">Used to indicate the file path of the file being read in.</param>
        public Dictionary<string,string> readFile(string fileName)
        {
            Dictionary<string, string> output = new Dictionary<string, string>();

            try
            {
                string csvText = System.IO.File.ReadAllText(fileName);

                using (System.IO.StringReader reader = new System.IO.StringReader(csvText))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] vals = line.Split(',');
                        output.Add(vals[0], line.Substring(vals[0].Length+1));
                    }
                }
            }
            catch (Exception ex)
            {
                if (!Settings.isOpen)
                { 
                   Window settings = new Settings();
                   settings.Show();
                   Settings.isOpen = true;
                }
                if (!isTesting)
                {
                    MessageBox.Show("CSV File not found, please update");
                }
                
            }
            return output;

        }
        // used to output a string keyvalue pair to a csv file
        /// <param name="fileName">Used to indicate the file path of the file being read in.</param>
        /// <param name="data">dictionary item to be written out to the file passed in</param>
        public void overwriteFile(string fileName,Dictionary<string, string> data)
        {
            string output = "";
            foreach(string key in data.Keys)
            {
                output += key + "," + data[key]+ Environment.NewLine;
            }
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                writer.Write(output);
            }
        }
    }
}

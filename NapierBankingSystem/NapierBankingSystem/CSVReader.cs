using System;
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
        public bool isTesting { get; set; } = false;

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

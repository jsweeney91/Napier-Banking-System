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
        public string fileName { get; set; }

        public Dictionary<string,string> readFile()
        {
            Dictionary<string, string> output = new Dictionary<string, string>();
            try
            {                
                string csvText = System.IO.File.ReadAllText(this.fileName);
                using (System.IO.StringReader reader = new System.IO.StringReader(csvText))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] vals = line.Split(',');
                        output.Add(vals[0], vals[1]);
                    }
                }
            }catch(Exception ex)
            {
                Window settings = new Settings();
                MessageBox.Show("CSV File not found, please update");
                settings.Show();
            }
            return output;

        }
        public void overwriteFile()
        {
            string output = "";
            foreach(string key in MessageHolder.textspeak.Keys)
            {
                output += key + "," + MessageHolder.textspeak[key]+ "\n";
            }
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                writer.Write(output);
            }
        }
    }
}

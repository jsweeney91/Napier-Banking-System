using System;
using System.Collections.Generic;
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
            string csvText = System.IO.File.ReadAllText(this.fileName);
            using (System.IO.StringReader reader = new System.IO.StringReader(csvText))
            {
                string line;
                while((line = reader.ReadLine())!= null)
                {                   
                    string[] vals = line.Split(',');
                    output.Add(vals[0], vals[1]);
                }      
            }
            return output;

        }
    }
}

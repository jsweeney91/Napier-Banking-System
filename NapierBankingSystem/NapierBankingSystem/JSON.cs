using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NapierBankingSystem
{
    class JSON
    {
        public string fileName { get; set; }

        public Dictionary<string, Message> readJSON()
        {
            Dictionary<string, Message> messages = new Dictionary<string, Message>();
            try
            {
               
                MessageProcessor convert = new MessageProcessor();
                if (this.fileName != null)
                {
                    string jsonText = System.IO.File.ReadAllText(this.fileName);
                    JObject jsonData = JObject.Parse(jsonText);
                    IList<JToken> results = jsonData["messages"].Children().ToList();
                    IList<MessageProcessor> output = new List<MessageProcessor>();
                    foreach (JToken result in results)
                    {
                        Message msg = JsonConvert.DeserializeObject<MessageProcessor>(result.ToString()).loadMessage();
                        msg.seen = true;
                        messages.Add(msg.messageID, msg);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("JSON File not found please update or a new file will be created");
                if (!Settings.isOpen)
                {
                    Window settings = new Settings();
                    settings.Show();
                    Settings.isOpen = true;
                }

            }
            return messages;
        }

        public void writeData()
        {
            List<MessageProcessor> output = new List<MessageProcessor>();
            foreach (Message m in MessageHolder.messages.Values)
            {
                output.Add(m.returnData());
            }
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(this.fileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                sw.WriteLine("{\"messages\": ");
                sw.WriteLine(JsonConvert.SerializeObject(output, Formatting.Indented));
                sw.WriteLine("}");
            }
         }
         
        
    }
}

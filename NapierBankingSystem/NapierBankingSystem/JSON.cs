using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapierBankingSystem
{
    class JSON
    {
        public string fileName { get; set; }

        public List<Message> readJSON()
        {
            List<Message> messages = new List<Message>();
            MessageProcessor convert = new MessageProcessor();
            if (this.fileName != null)
            {
                string jsonText = System.IO.File.ReadAllText(this.fileName);
                JObject jsonData = JObject.Parse(jsonText);
                IList<JToken> results = jsonData["messages"].Children().ToList();
                IList<MessageProcessor> output = new List<MessageProcessor>();
                foreach(JToken result in results)
                {              
                    Message msg = JsonConvert.DeserializeObject<MessageProcessor>(result.ToString()).returnMessage();
                    messages.Add(msg);
                }
            }
            return messages;
        }
        
    }
}

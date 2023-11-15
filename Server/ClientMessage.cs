using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Server
{
    public class ClientMessage
    {
        public string Name { get; set; }
        public string Message { get; set; }

        public ClientMessage(string name, string message)
        {
            Name = name;
            Message = message;
        }

        public string SerializeMessage(ClientMessage message)
        {
            string jsonMessage = JsonSerializer.Serialize<ClientMessage>(message);

            return jsonMessage;
        }

        public static ClientMessage DeserializeMessage(string jsonMessage)
        {
            ClientMessage message = JsonSerializer.Deserialize<ClientMessage>(jsonMessage);
            if (message == null)
            {
                throw new Exception("Присланное клиентом сообщение = null");
            }
            return message;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Client
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

        public string SerializeMessage()
        {
            string jsonMessage = JsonSerializer.Serialize<ClientMessage>(this);

            return jsonMessage;
        }

        public ClientMessage DeserializeMessage(string jsonMessage)
        {
            ClientMessage message = JsonSerializer.Deserialize<ClientMessage>(jsonMessage);
            if(message == null)
            {
                throw new Exception("Присланное клиентом сообщение = null");
            }
            return message;
        }

        public static ClientMessage CreateMessage()
        {
            Console.Write("Введите выше имя: ");
            string? name = Console.ReadLine();
            Console.Write("Введите сообщение: ");
            string? message = Console.ReadLine();

            return new ClientMessage(name, message);

        }
    }
}

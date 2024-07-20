using System.Text.Json;

namespace Async
{
    internal class Message
    {
        public string Name { get; set; }
        public string TextMessage { get; set; }
        public DateTime DateTime { get; set; }

        public Message() { }

        public Message(string nikName, string textMessage)
        {
            Name = nikName;
            TextMessage = textMessage;
            DateTime = DateTime.Now;
        }

        public string ToJSON()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Message? FromJSON(string message)
        {
            return JsonSerializer.Deserialize<Message>(message);
        }

        public override string ToString()
        {
            return $"Get message from {Name} ({DateTime.ToShortTimeString()}) :\n{TextMessage}";
        }
    }
}


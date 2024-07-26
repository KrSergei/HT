using System.Text.Json;

namespace Ptrn
{
    internal class Message
    {
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string TextMessage { get; set; }
        public DateTime DateTime { get; set; }

        public Message() { }

        public Message(string nikName, string textMessage)
        {
            FromName = nikName;
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
            return $"Get message from {FromName} ({DateTime.ToShortTimeString()}) :\n{TextMessage}";
        }
    }
}

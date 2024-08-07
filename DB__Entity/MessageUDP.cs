using System.Text.Json;

namespace DB__Entity
{
    public enum Command
    {
        Registred,
        Message,
        Confirmation
    }

    public class MessageUDP
    {
        public Command command { get; set; }
        public int? Id { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string TextMessage { get; set; }
        public DateTime DateTime { get; set; }

        public MessageUDP() { }

        public MessageUDP(string nikName, string textMessage)
        {
            FromName = nikName;
            TextMessage = textMessage;
            DateTime = DateTime.Now;
        }


        public string ToJSON()
        {
            return JsonSerializer.Serialize(this);
        }

        public static MessageUDP FromJSON(string json)
        {
            return JsonSerializer.Deserialize<MessageUDP>(json);
        }

        public override string ToString()
        {
            return $"Get message from {FromName} ({DateTime.ToShortTimeString()}) :\n{TextMessage}";
        }
    }
}

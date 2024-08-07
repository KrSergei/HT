using System.Net;

namespace DB__Entity.Abstraction
{
    public interface IMessageSource
    {
        public void SendMessage(MessageUDP messageUDP, IPEndPoint ep);
        public MessageUDP ReceiveMessage(ref IPEndPoint ep);        
    }
}

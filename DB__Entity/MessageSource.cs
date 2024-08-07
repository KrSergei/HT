using DB__Entity.Abstraction;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace DB__Entity
{
    public class MessageSource : IMessageSource
    {
        private readonly UdpClient _udpClient;

        public MessageSource(int port)
        {
            _udpClient = new UdpClient(port);
        }

        public MessageUDP ReceiveMessage(ref IPEndPoint ep)
        {
            byte[] answerData = _udpClient.Receive(ref ep);
            string json = Encoding.UTF8.GetString(answerData);
            return  MessageUDP.FromJSON(json);
        }

        public void SendMessage(MessageUDP messageUDP, IPEndPoint ep)
        {     
            string json = messageUDP.ToJSON();
            byte[] responseData = Encoding.UTF8.GetBytes(json);
            _udpClient.Send(responseData, responseData.Length, ep);
        }
    }
}

using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ChatApp
{
    internal class Client
    {
        public static void SendMsg(string name)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16874);
            UdpClient udpClient = new UdpClient();
            Message message = new Message(name, "Hello");
            string responseMsgJs = message.ToJSON();
            byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
            udpClient.Send(responseData, ep);

            byte[] answerData = udpClient.Receive(ref ep);
            string answerMsgJs = Encoding.UTF8.GetString(answerData);
            Message? answerMsg = Message.FromJSON(answerMsgJs);
            Console.WriteLine(answerMsg.ToString());
        }
    }
}

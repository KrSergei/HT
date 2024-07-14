using System.Net.Sockets;
using System.Net;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ChatApp
{
    internal class Client
    {
        public static void SendMsg(string name)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16874);
            UdpClient udpClient = new UdpClient();
            string? enterText = Console.ReadLine();

            Message message = new Message(name, enterText);
            string responseMsgJs = message.ToJSON();
            byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
            udpClient.Send(responseData, ep);

            if (enterText.Equals("Exit")) Environment.Exit(0);

            byte[] answerData = udpClient.Receive(ref ep);
            string answerMsgJs = Encoding.UTF8.GetString(answerData);
            Message? answerMsg = Message.FromJSON(answerMsgJs);
            Console.WriteLine(answerMsg.ToString());
        }
    }
}

using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Ptrn
{
    internal class Client
    {
        public static async Task SendMsg(string name)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16879);
            UdpClient udpClient = new UdpClient();
            Console.WriteLine("Enter recipient");
            string toName = Console.ReadLine();
            if (string.IsNullOrEmpty(toName)){
                Console.WriteLine("Enter recipient's name");
            Console.WriteLine("Enter message");
            string? enterText = Console.ReadLine();
            if (enterText.Equals("Exit")) Environment.Exit(0);


            Message message = new Message(name, enterText);
            message.ToName = Console.ReadLine();
            string responseMsgJs = message.ToJSON();
            byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
            await udpClient.SendAsync(responseData, ep);


            byte[] answerData = udpClient.Receive(ref ep);
            string answerMsgJs = Encoding.UTF8.GetString(answerData);
            Message? answerMsg = Message.FromJSON(answerMsgJs);
            Console.WriteLine(answerMsg.ToString());
        }
    }
}

using System.Net.Sockets;
using System.Net;
using System.Text;
using DB__Entity.Models;


namespace DB__Entity
{
    internal class Client
    {
        public static async Task SendMsg(string name)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16879);
            UdpClient udpClient = new UdpClient();

            while (true)
            {
                Console.WriteLine("Enter you'r name");
                name = Console.ReadLine();
                Console.WriteLine("Enter recipient");
                string? toName = Console.ReadLine();

                if (string.IsNullOrEmpty(toName))
                {
                    Console.WriteLine("You are didn't enter the recipient name");
                    continue;
                }
                else
                {
                    Console.WriteLine("Enter message");
                    string? enterText = Console.ReadLine();

                    MessageUDP message = new MessageUDP(name, enterText);
                    message.ToName = toName;
                    message.FromName = name;
                    message.TextMessage = enterText;
                    string responseMsgJs = message.ToJSON();
                    byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
                    await udpClient.SendAsync(responseData, ep);

                    if (enterText.Equals("Exit")) Environment.Exit(0);

                    byte[] answerData = udpClient.Receive(ref ep);
                    string answerMsgJs = Encoding.UTF8.GetString(answerData);
                    MessageUDP? answerMsg = MessageUDP.FromJSON(answerMsgJs);
                    Console.WriteLine(answerMsg.ToString());
                }
            }
        }
    }
}

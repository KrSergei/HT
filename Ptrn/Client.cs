using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace Ptrn
{
    internal class Client
    {
        public static async Task ClientSendlerAsync(string? name = null)
        {
            Console.WriteLine("ClientSendlerAsync started");
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

                    Message message = new Message(name, enterText);
                    message.ToName = toName;
                    string responseMsgJs = message.ToJSON();
                    byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
                    await udpClient.SendAsync(responseData, ep);

                    if (enterText.Equals("Exit")) Environment.Exit(0);

                    byte[] answerData = udpClient.Receive(ref ep);
                    string answerMsgJs = Encoding.UTF8.GetString(answerData);
                    Message? answerMsg = Message.FromJSON(answerMsgJs);
                    Console.WriteLine(answerMsg.ToString());
                }
            }
        }

        public static async Task ClientListenerAsync()
        {
            Console.WriteLine("ClientListenerAsync started");
            await Task.Run(() => ClientListener());
        }

        public static void ClientListener() 
        {
            Console.WriteLine("ClientListener started");
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16879);
            UdpClient udpClient = new UdpClient();

            while (true)
            {   
                    byte[] answerData = udpClient.Receive(ref ep);
                    string answerMsgJs = Encoding.UTF8.GetString(answerData);
                    Message? answerMsg = Message.FromJSON(answerMsgJs);
                    Console.WriteLine(answerMsg.ToString());
            }
        }

        public static async Task SendMsg(string? name = null)
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

                    Message message = new Message(name, enterText);
                    message.ToName = toName;
                    string responseMsgJs = message.ToJSON();
                    byte[] responseData = Encoding.UTF8.GetBytes(responseMsgJs);
                    await udpClient.SendAsync(responseData, ep);

                    if (enterText.Equals("Exit")) Environment.Exit(0);

                    byte[] answerData = udpClient.Receive(ref ep);
                    string answerMsgJs = Encoding.UTF8.GetString(answerData);
                    Message? answerMsg = Message.FromJSON(answerMsgJs);
                    Console.WriteLine(answerMsg.ToString());
                }
            }
        }
    }
}

using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ChatApp
{
    internal class Chat
    {
        public static void Server()
        {
            IPEndPoint localEP = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(12345);
            Console.WriteLine("Server waiting a message from client");
            while (true)
            {
                try
                {
                    byte[] buffer = udpClient.Receive(ref localEP);
                    string str1 = Encoding.UTF8.GetString(buffer);
                    Message? someMsg = Message.FromJSON(str1);

                    if (someMsg != null)
                    {
                        Console.WriteLine(someMsg.ToString());

                        Message newMesg = new Message("Server", "Message getted");
                        string js = newMesg.ToJSON();
                        byte[] bytes = Encoding.UTF8.GetBytes(js);
                        udpClient.Send(bytes, localEP);
                    }
                    else
                        Console.WriteLine("Incorrect message");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void Client(string nik)
        {
            IPEndPoint localEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12345);
            UdpClient udpClient = new UdpClient();

            while (true)
            {
                Console.WriteLine("Enter message");
                string textMesg = Console.ReadLine();
                if (String.IsNullOrEmpty(textMesg))
                {
                    break;
                }
                Message newMesg = new Message(nik, textMesg);
                string js = newMesg.ToJSON();
                byte[] bytes = Encoding.UTF8.GetBytes(js);
                udpClient.Send(bytes, localEP);

                ///Получение ответа от сервера
                byte[] buffer = udpClient.Receive(ref localEP);
                string str1 = Encoding.UTF8.GetString(buffer);
                Message? someMsg = Message.FromJSON(str1);
                Console.WriteLine(someMsg);
            }
        }
    }
}

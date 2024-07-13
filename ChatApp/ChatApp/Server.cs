using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ChatApp
{
    internal class Server
    {
        public static void AcceptMag()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(16874);
            Console.WriteLine("Server is waiting a messages");
            while (true) {
                byte[] buffer = udpClient.Receive(ref ep);            
                string str = Encoding.UTF8.GetString(buffer);
                Thread thread = new Thread(() =>
                {
                    Message message = Message.FromJSON(str);
                    Console.WriteLine(message.ToString());

                    Message responseMsg = new Message("Server", "Message getted");
                    string js = responseMsg.ToJSON();
                    byte[] responseData = Encoding.UTF8.GetBytes(js);
                    udpClient.Send(responseData, ep);

                });
                thread.Start();
            }
        }
    }
}

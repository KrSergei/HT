using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Async
{
    internal class Server
    {
        public static async Task AcceptMag()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(16879);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Console.WriteLine("Server is waiting a messages");

            while (true)
            {
                var data = udpClient.Receive(ref ep);
                string str = Encoding.UTF8.GetString(data);
                string exitWord = "";
                ConsoleKeyInfo ch;

                await Task.Run(async () =>
                {
                    Message message = Message.FromJSON(str);
                    exitWord = message.TextMessage;
                    //выход из приложения по поступлении команды Exit пользователя и после нажатия любой клавиши

                    token.Register(() =>
                    {
                        ch = Console.ReadKey();
                        exitWord.Equals("Exit");
                    });
                    Message responseMsg = new Message("Server", "Message getted");
                    string js = responseMsg.ToJSON();
                    byte[] responseData = Encoding.UTF8.GetBytes(js);
                    await udpClient.SendAsync(responseData, ep);
                }, token);

                if (exitWord.Equals("Exit"))
                {
                    Console.WriteLine("The last user left the chat.\nPress any key to turn off");
                    cancellationTokenSource.Cancel();
                    cancellationTokenSource.Dispose();

                    ch = Console.ReadKey();
                    if (ch.Key != null) Environment.Exit(0);
                }
                else
                    Console.WriteLine(exitWord.ToString());
            }
        }
    }
}

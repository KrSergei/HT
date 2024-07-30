using System.Net.Sockets;
using System.Net;
using System.Text;


namespace Ptrn
{
    internal class Server
    {
        public static async Task AcceptMsg()
        {
            Dictionary<string, IPEndPoint> users = new Dictionary<string, IPEndPoint>();
            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(16879);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
            bool _isExit = false;
            Console.WriteLine("Server is waiting a messages");

            while (true)
            {
                var data = udpClient.Receive(ref ep);
                string str = Encoding.UTF8.GetString(data);
                string exitWord = "";
                ConsoleKeyInfo ch;

                await Task.Run(async () =>
                {
                    Message? message = Message.FromJSON(str);
                    exitWord = message.TextMessage;
                    //выход из приложения по поступлении команды Exit пользователя и после нажатия любой клавиши
                    token.Register(() =>
                    {
                        ch = Console.ReadKey();
                        exitWord.Equals("Exit");
                    });

                    Message? responseMsg = new Message();

                    if (message.ToName.Equals("Server"))
                    {
                        Console.WriteLine("Call server");
                        if (message.TextMessage.ToLower().Equals("Reg"))
                        {   
                            if (users.TryAdd(message.FromName, ep))
                            {
                                responseMsg = new Message("Server", $"User added: {message.FromName}");
                            }
                        }
                        else if (message.TextMessage.ToLower().Equals("delete"))
                        {  
                            users.Remove(message.FromName);
                            responseMsg = new Message("Server", $"User  {message.FromName} delete");
                        }
                        else if (message.TextMessage.ToLower().Equals("list"))
                        {
                            StringBuilder sb = new StringBuilder();
                            foreach (var user in users)
                            {
                                sb.Append(user.Key + "\n");
                            }
                            responseMsg = new Message("Server", $"User's list:\n{sb.ToString()}");
                        }
                    }
                    else if (message.ToName.ToLower().Equals("all"))
                    {
                        foreach (var user in users) 
                        {
                            message.ToName = user.Key;
                            string js1 = message.ToJSON();
                            byte[] responseData1 = Encoding.UTF8.GetBytes(js1);
                            await udpClient.SendAsync(responseData1, user.Value);
                        }
                        responseMsg = new Message("Server", $"Message send all users");
                    }
                    else if(users.TryGetValue(message.ToName, out IPEndPoint? value))
                    {
                        string js1 = message.ToJSON();
                        byte[] responseData1 = Encoding.UTF8.GetBytes(js1);
                        await udpClient.SendAsync(responseData1, value);
                        responseMsg = new Message("Server", $"For user {message.ToName} send message");
                    }
                    else
                    {
                        responseMsg = new Message("Server", $"This user {message.ToName} not have");
                    }

                    string js = responseMsg.ToJSON();
                    byte[] responseData = Encoding.UTF8.GetBytes(js);
                    await udpClient.SendAsync(responseData, ep);

                    if (exitWord.Equals("Exit"))
                    {                 
                        _isExit = true;
                    }
                    else
                        Console.WriteLine($"Now: {DateTime.Now.ToString("dd : MM : yyyy | HH : mm : ss")}" +
                            $"\nFrom user: {message.FromName} " +
                            $"\nSended message: {exitWord.ToString()} " +
                            $"\nTo user: {message.ToName}");
                }, token);

                if (_isExit)
                {
                    Console.WriteLine("The last user left the chat.\nPress any key to turn off");
                    cancellationTokenSource.Cancel();
                    cancellationTokenSource.Dispose();
                    ch = Console.ReadKey();
                    if (ch.Key != null) Environment.Exit(0);
                }
            }
        }
    }
}

using System.Net.Sockets;
using System.Net;
using System.Text;
using DB__Entity.Models;
using Microsoft.EntityFrameworkCore;
using DB__Entity.Abstraction;

namespace DB__Entity
{
    internal class Server
    {
        private readonly IMessageSource _messageSource;
        private readonly IPEndPoint _endPoint;

        public Server(MessageSource messageSource, IPEndPoint endPoint)
        {
            _messageSource = messageSource;
            _endPoint = endPoint;
        }


        public static async Task AcceptMsg()
        {
            Dictionary<string, IPEndPoint> users = new Dictionary<string, IPEndPoint>();

            IPEndPoint ep = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient = new UdpClient(16879);
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;
 
            var optionBuilder = new DbContextOptionsBuilder<Context>()
                                .UseNpgsql("Host=localhost;Username=postgres;Password=1;Database=ChatDb")
                                .UseLazyLoadingProxies();

            bool _isExit = false;
            Console.WriteLine("Server is waiting an messages");

            while (true)
            {
                var data = udpClient.Receive(ref ep);
                string str = Encoding.UTF8.GetString(data);
                string msgIncoming = "";
                ConsoleKeyInfo ch;

                await Task.Run(async () =>
                {
                    MessageUDP? message = MessageUDP.FromJSON(str);
                    msgIncoming = message.TextMessage;
                    //выход из приложения по поступлении команды Exit пользователя и после нажатия любой клавиши
                    token.Register(() =>
                    {
                        ch = Console.ReadKey();
                        msgIncoming.Equals("Exit");
                    });

                    MessageUDP responseMsg = new MessageUDP();

                    if (message.ToName.Equals("Server"))
                    {
                        if (message.TextMessage.ToLower().Equals("reg"))
                        {
                            if (users.TryAdd(message.FromName, ep))
                            {
                                responseMsg = new MessageUDP("Server", $"User added: {message.FromName}");
                                await DbCRUD.AddUserToDb(message.FromName);
                            }
                        }
                        else if (message.TextMessage.ToLower().Equals("delete"))
                        {
                            users.Remove(message.FromName);
                            responseMsg = new MessageUDP("Server", $"User  {message.FromName} delete");
                        }
                        else if (message.TextMessage.ToLower().Equals("list"))
                        {
                            StringBuilder sb = new StringBuilder();
                            foreach (var user in users)
                            {
                                sb.Append(user.Key + "\n");
                            }
                            responseMsg = new MessageUDP("Server", $"User's list:\n{sb.ToString()}");
                        }
                        else if (message.TextMessage.ToLower().Equals("unread")) //возвращение списка непрочитанных сообщений
                        {
                            var unreadMsg = new List<string>(); //инициализация списка
                            int userId = await DbCRUD.GetUserId(message.FromName);    //получение ID пользователя               
                            unreadMsg = await DbCRUD.GetUreadMessages(userId);  //заполнеине списка непрочитанных сообщений

                            //создане строки из списка  непрочитанных сообщений
                            StringBuilder sb = new StringBuilder();
                            foreach (var msg in unreadMsg)
                            {
                                sb.Append(msg + "\n");
                            }
                            //создание ответного сообщения
                            responseMsg = new MessageUDP("Server", $"User's unreadig message list:\n{sb.ToString()}");
                        }
                        else return;
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
                        responseMsg = new MessageUDP("Server", $"Message send all users");
                    }
                    else if (users.TryGetValue(message.ToName, out IPEndPoint? value))
                    {
                        string js1 = message.ToJSON();
                        byte[] responseData1 = Encoding.UTF8.GetBytes(js1);
                        await udpClient.SendAsync(responseData1, value);
                        responseMsg = new MessageUDP("Server", $"For user {message.ToName} send message");
                    }
                    else if (msgIncoming.Equals("Exit"))
                    {
                        _isExit = true;
                    }
                    else
                    {
                        if (await DbCRUD.IsExistUser(message.ToName)) //Проверка имени адресата в базе данных
                        {
                            int idFromUser = await DbCRUD.GetUserId(message.FromName);
                            int idToUser = await DbCRUD.GetUserId(message.ToName);

                            await DbCRUD.AddMessageToDb(idFromUser, idToUser, message.TextMessage, GetRandomBoolValue());
                            Console.WriteLine($"Save message to DB: {DateTime.Now.ToString("dd : MM : yyyy | HH : mm : ss")}" +
                                $"\nFrom user: {message.FromName} " +
                                $"\nSended message: {msgIncoming.ToString()} " +
                                $"\nTo user: {message.ToName}");
                            responseMsg = new MessageUDP("Server", $"This user {message.ToName} send message");
                        }
                        else
                        {
                            responseMsg = new MessageUDP("Server", $"There is no user with that name : {message.ToName}");
                        }
                    }

                    string js = responseMsg.ToJSON();
                    byte[] responseData = Encoding.UTF8.GetBytes(js);
                    await udpClient.SendAsync(responseData, ep);

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
        /// <summary>
        /// Имитация доставки сообщения пользователю
        /// </summary>
        /// <returns></returns>
        private static bool GetRandomBoolValue()
        {
            Random rng = new Random();
            bool randomBool =  rng.Next(0, 2) > 0;
            return randomBool;
        }
    }
}
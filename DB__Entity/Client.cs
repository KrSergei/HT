using System.Net.Sockets;
using System.Net;
using System.Text;
using DB__Entity.Abstraction;


namespace DB__Entity
{
    public class Client
    {
        private readonly string _name;
        private readonly IMessageSource _messageSource;
        private readonly IPEndPoint _endPoint;

        public Client(MessageSource messageSource, IPEndPoint endPoint, string name)
        {
            _messageSource = messageSource;
            _endPoint = endPoint;
            _name = name;
        }

        private void Registred() 
        {

            var messageJSON = new MessageUDP()
            {
                command = Command.Registred,
                FromName = _name 
            };
            _messageSource.SendMessage(messageJSON, _endPoint);
        }

        public void ClientSendler()
        {           
            while (true)
            {
                Console.WriteLine("Enter recipient");
                string? toName = Console.ReadLine();

                if (string.IsNullOrEmpty(toName))
                {
                    Console.WriteLine("You are need enter the recipient name");
                    continue;
                }
                else
                {
                    Console.WriteLine("Enter message");
                    string? enterText = Console.ReadLine();

                    var messageJSON = new MessageUDP()
                    {
                        TextMessage = enterText,
                        ToName = toName
                    };

                    _messageSource.SendMessage(messageJSON, _endPoint);
                }
            }
        }

        public void ClientListener() 
        {
            Registred();
            IPEndPoint ep = new IPEndPoint(_endPoint.Address, _endPoint.Port);
            while (true)
            {
               MessageUDP message = _messageSource.ReceiveMessage(ref ep);
               Console.WriteLine(message.ToString());
            }
        }

        #region Working var
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
        #endregion
    }
}

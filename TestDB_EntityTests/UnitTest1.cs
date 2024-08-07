using DB__Entity;
using DB__Entity.Abstraction;
using System.Net;

namespace TestDB_EntityTests
{
    public class Tests
    {
        IMessageSource _source;
        IPEndPoint _endPoint;

        [SetUp]
        public void Setup()
        {
           
            _endPoint = new IPEndPoint(IPAddress.Any, 0);
        }

        [Test]
        public void TestResiveMessage()
        {
            _source = new MockMessageSource();
            var result = _source.ReceiveMessage(ref _endPoint);
            Assert.IsNotNull(result);
            Assert.IsNull(result.TextMessage);
            Assert.That("Vasya", Is.EqualTo(result.FromName));
            Assert.That(Command.Registred, Is.EqualTo(result.command));
        }
    }

    public class MockMessageSource : IMessageSource
    {
        private Queue<MessageUDP> messages = new();
        private IMessageSource server;
        private IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);

        public MockMessageSource() 
        {
            messages.Enqueue( new MessageUDP { command = Command.Registred, FromName = "Vasya" });
            messages.Enqueue( new MessageUDP { command = Command.Registred, FromName = "Olya" });
            messages.Enqueue( new MessageUDP { command = Command.Message, FromName = "Olya", ToName = "Vasya", TextMessage = "From Olya" });
            messages.Enqueue( new MessageUDP { command = Command.Message, FromName = "Vasya", ToName = "Olya", TextMessage = "From Vasya" });
        }

        public MessageUDP ReceiveMessage(ref IPEndPoint ep)
        {
            return messages.Peek();
        }

        public void SendMessage(MessageUDP messageUDP, IPEndPoint ep)
        {
            messages.Enqueue(messageUDP);
        }
    }
}
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

        [Test]
        public void TestSendMessage()
        {
            _source = new MockClientMessageSource();

            MessageUDP messageUDP = new MessageUDP() 
            { 
                command = Command.Message,
                FromName = "Olya",
                ToName = "Vasya",
                TextMessage = "From Olya"

            };
            _source.SendMessage(messageUDP, _endPoint);

            var result = _source.ReceiveMessage(ref _endPoint);
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.TextMessage);
            Assert.That(Command.Message, Is.EqualTo(result.command));
            Assert.That("Olya", Is.EqualTo(result.FromName));
            Assert.That("Vasya", Is.EqualTo(result.ToName));
            Assert.That("From Olya", Is.EqualTo(result.TextMessage));
        }
    }

    public class MockMessageSource : IMessageSource
    {
        private Queue<MessageUDP> messages = new();
       

        public MockMessageSource() 
        {
            messages.Enqueue(new MessageUDP { command = Command.Registred, FromName = "Vasya" });
            messages.Enqueue(new MessageUDP { command = Command.Registred, FromName = "Olya" });
            messages.Enqueue(new MessageUDP { command = Command.Message, FromName = "Olya", ToName = "Vasya", TextMessage = "From Olya" });
            messages.Enqueue(new MessageUDP { command = Command.Message, FromName = "Vasya", ToName = "Olya", TextMessage = "From Vasya" });
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


    public class MockClientMessageSource : IMessageSource
    {
        private Queue<MessageUDP> messages = new();

        public MessageUDP ReceiveMessage(ref IPEndPoint ep)
        {
            return messages.Dequeue();
        }

        public void SendMessage(MessageUDP messageUDP, IPEndPoint ep)
        {
            messages.Enqueue(messageUDP);
        }
    }
}

namespace ChatApp
{
    class Programm
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Server.AcceptMag();
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    new Thread(() =>
                    {
                        Client.SendMsg($"{args[0]} {i}");
                    }).Start();
                }
            }
        }
    }
}
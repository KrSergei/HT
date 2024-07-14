
namespace ChatApp
{
    class Programm
    {
        public static void Main(string[] args)
        {
            while (true) 
            {
                if (args.Length == 0)
                {
                    Server.AcceptMag();
                }
                else
                {
                    new Thread(() =>
                    {
                        Client.SendMsg($"{args[0]}");
                    }).Start();

                    
                    //for (int i = 0; i < 10; i++)
                    //{
                    //    new Thread(() =>
                    //    {
                    //        Client.SendMsg($"{args[0]} {i}");
                    //    }).Start();
                    //}
                }
            }
        }
    }
}
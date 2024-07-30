namespace Ptrn
{
    class Programm
    {
        public static async Task Main(string[] args)
        {
            while (true)
            {
                if (args.Length == 0)
                {
                    await Server.AcceptMsg();
                }
                else
                {
                    ///working variant
                    await Client.SendMsg(args[0]);

                    //await Client.ClientSendlerAsync(args[0]);
                    //await Client.ClientListenerAsync();
                }
            }
        }
    }
}

using DB__Entity;
using DB__Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace DB_Entity
{
    class Programm
    {
        public static async Task Main(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<Context>().UseNpgsql().UseLazyLoadingProxies();
            while (true)
            {
                if (args.Length == 0)
                {
                    await Server.AcceptMsg();
                }
                else
                {
                    await Client.SendMsg(args[0]);
                }
            }
        }
    }
}

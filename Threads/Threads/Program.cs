using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Threads
{
    class Programm
    {
        #region Task1
        //static int[] array1 = { 1, 3, 5, 7, 9 };
        //static int[] array2 = { 2, 4, 6, 8, 10 };

        //static int var1;
        //static int var2;
        //public static void Summ1()
        //{
        //    var1 = 0;
        //    var1 = array1.Sum();
        //}

        //public static void Summ2()
        //{
        //    var2 = 0;
        //    var2 = array2.Sum();
        //}
        #endregion
        public static void Main(string[] args)
        {
            #region Task1
            //Thread thread1 = new Thread(Summ1);
            //thread1.Start();
            //thread1.Join();
            //Console.WriteLine(var1);

            //Thread thread2 = new Thread(Summ2);
            //thread2.Start();
            //thread2.Join();
            //Console.WriteLine(var2);
            //var summ = var1 + var2;
            //Console.WriteLine($"Summ {var1} + {var2} = " + summ);
            #endregion

            #region Task2
            string urlResources1 = "mail.ru";
            var IpAdresses = Dns.GetHostAddresses(urlResources1, AddressFamily.InterNetwork);
            foreach (var address in IpAdresses)
            {
                Console.WriteLine(address);
            }
            Dictionary<IPAddress, long> pings = new Dictionary<IPAddress, long>();
            List<Thread> threads = new List<Thread>();
            foreach (var adress in IpAdresses) {
                var tr = new Thread(() =>
                {
                    Ping ping = new Ping();
                    PingReply pingReply = ping.Send(adress);
                    pings.Add(adress, pingReply.RoundtripTime);
                });
                threads.Add(tr);
                tr.Start();                
            }
            foreach (var item in threads)
            {
                item.Join();
            }
            long minPing = long.MaxValue;
            foreach (var ping in pings)
            {
                if(ping.Value < minPing) 
                    minPing = ping.Value;
                Console.WriteLine($"IP : {ping.Key}, ping : { ping.Value}");
            }
            Console.WriteLine($"Min ping = {minPing} ms");
        }
        #endregion
    }
}
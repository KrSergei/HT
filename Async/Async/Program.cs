using System.Net;
using System.Net.NetworkInformation;

namespace Async
{
    class Programm
    {
        #region Task1
        //static int[] array1 = Enumerable.Range(0, 1000).Select(x => Random.Shared.Next(0, 10)).ToArray();
        //static int[] array2 = Enumerable.Range(0, 1000).Select(x => Random.Shared.Next(0, 10)).ToArray();

        //static async Task<int> Sum(int[] array)
        //{
        //    await Task.CompletedTask;
        //    int sum = array.Sum(x => x);
        //    return sum;
        //}
        #endregion Task1

        #region ping
        //static async Task<long> GetPing(IPAddress iPAddress)
        //{
        //    Ping ping = new Ping();
        //    PingReply pingReply = await ping.SendPingAsync(iPAddress);
        //    return pingReply.RoundtripTime;
        //}
        #endregion

        public static async Task Main(string[] args)
        {
            #region Task1
            //var res1 =  Sum(array1);
            //var res2 =  Sum(array2);
            //Console.WriteLine(await res1);
            //Console.WriteLine(await res2);
            //int sum = res1.Result +  res2.Result;
            //Console.WriteLine($"Sum = {sum}");
            #endregion

            #region Ping
            //string urlAdress = "google.com";

            //IPAddress[] iPAddresses = await Dns.GetHostAddressesAsync(urlAdress);

            //foreach (var address in iPAddresses)
            //{
            //    await Console.Out.WriteLineAsync(address.ToString());
            //}

            //Dictionary<IPAddress, long> pings = new Dictionary<IPAddress, long>();

            //foreach (var adress in iPAddresses)
            //{
            //    pings.Add(adress, await GetPing(adress));
            //}
            //int minPingValue = int.MaxValue;

            //foreach (var item in pings)
            //{
            //    await Console.Out.WriteLineAsync($"IPadress : {item.Key}, ping : {item.Value}");
            //    if(item.Value < minPingValue) minPingValue = (int)item.Value;
            //}
            //Console.WriteLine($"Min ping value = {minPingValue}");
            #endregion

            #region ChatApp

            while (true)
            {
                if (args.Length == 0)
                {
                    await Server.AcceptMag();
                }
                else
                {
                    await Client.SendMsg($"{args[0]}");
                }
            }
            #endregion
        }
    }
}

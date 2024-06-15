using System.Net.Http.Metrics;

class Programm
{
    class Metric : IComparable<Metric>
    {
        public int Month;
        public int Temperature;
        public int Days;

        public int CompareTo(Metric metric)
        {  
            int res = this.Month.CompareTo(metric.Month);
            if (res != 0)
            {
                return res;
            }
            else
            {
                return this.Temperature.CompareTo(metric.Temperature);
            }
        }

        public override string ToString()
        {
            return $"{Month}, {Temperature}, {Days}";
        }
    }

    static void Main()
    {
        Metric[] temperatures = new Metric[]
        {
            new Metric { Month = 1, Temperature = -1, Days = 10 },
            new Metric { Month = 0, Temperature = 22, Days = 7 },
            new Metric { Month = 1, Temperature = -10, Days = 5 },
            new Metric { Month = 0, Temperature = 10, Days = 15 },
            new Metric { Month = 2, Temperature = -2, Days = 4 },
            new Metric { Month = 1, Temperature = -30, Days = 4 },
            new Metric { Month = 2, Temperature = -2, Days = 3 },
        };

        Array.Sort(temperatures);
        foreach(var t in temperatures)
        {
            Console.WriteLine(t + " ");
        }

    } 
}

using Htask3_2;

class Programm
{
    static void Main(string[] args)
    {
        #region Task2
        //List<int> ints = new List<int> { 1, 2, 2, 2, 3, 4, 4, 5, 5, 5, 5, 6, 7, 0 };
        //Dictionary<int, int> dict = new Dictionary<int, int>();
        //foreach (int i in ints)
        //{
        //    if (dict.ContainsKey(i))
        //        dict[i]++;
        //    else
        //        dict.Add(i, 0);
        //}

        //PriorityQueue<int, int> prQue = new PriorityQueue<int, int>();
        //foreach (var item in dict)
        //{
        //    prQue.Enqueue(item.Key, item.Value * - 1);
        //}
        //while(prQue.Count > 0) Console.WriteLine(prQue.Dequeue());
        #endregion
        #region Task3
        //List<User> users = new List<User>();
        //users.Add(new User("Petr", "Ivanov", 25));
        //users.Add(new User("Petr", "Petrov", 35));
        //users.Add(new User("Denis", "Ivanov", 25));
        //users.Add(new User("Ivan", "Sidorov", 37));
        //users.Add(new User("Petr", "Ivanov", 27));
        //users.Add(new User("Ivan", "Petrov", 35));

        //var resultFirstName = users.GroupBy(u => u.FirstName).OrderByDescending(x => x.Count()).First().Key;
        //Console.WriteLine(resultFirstName);
        //var resultAge = users.GroupBy(a => a.Age).OrderBy(x => x.Count()).First().Key;
        //Console.WriteLine(resultAge);
        //var resultLastName = users.GroupBy(a => a.LastName).OrderBy(x => x.Count()).Last().Key;
        //Console.WriteLine(resultLastName);
        #endregion
        #region Task4
        //List<string> strlist = new List<string>() 
        //{ 
        //    "Tokyo",
        //    "Kyoto",
        //    "Nara",
        //    "Ueda",
        //    "Nagoya",
        //    "Karuidzawa"
        //};

        //string str = "yo";
        //var res = strlist.Where(s => s.ToUpper().Contains(str.ToUpper())).Select(x => x.ToUpper());

        //Console.WriteLine(string.Join(' ', res));

        #endregion
        #region HTask
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        int value = 18;
        var s = new HashSet<int>();

        for (int i = 0; i < array.Length - 1; i++)
        {
            var x = value - array[i] - array[i + 1];
            if (s.Contains(x))
            {
                Console.WriteLine($"{value} = {x} + {array[i]} + {array[i + 1]}");
            }
            else
            {
                s.Add(array[i]);
                s.Add(array[i + 1]);
            }
        }
        #endregion
    }
}
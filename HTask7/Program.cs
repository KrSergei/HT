using System.Reflection;
using System.Text;

namespace HTask7
{
    
    internal class Program
    {
        public static TestClass? MakeTestClass()
        {
            Type testClass = typeof(TestClass);
            return Activator.CreateInstance(testClass) as TestClass;
        }

        public static TestClass? MakeTestClass(int value)
        {
            Type testClass = typeof(TestClass);
            return Activator.CreateInstance(testClass, new object[]{ value }) as TestClass;
        }

        public static TestClass? MakeTestClass(int i, string s, decimal d, char[] c)
        {
            Type testClass = typeof(TestClass);
            return Activator.CreateInstance(testClass, new object[] { i, s, d, c }) as TestClass;
        }

        static object? StringToObject(string s)
        {
            string[] arr = s.Split("|");
            string[] arr1 = arr[0].Split(":");
            object some = Activator.CreateInstance(null, arr1[0].Split(',')[0]);
            if(arr1.Length > 1 && some != null)
            {
                var type = some.GetType();
                for (int i = 1; i < arr.Length; i++)
                {
                    string[] nameAndValue = arr[i].Split(':');
                    var p = type.GetProperty(nameAndValue[0]);
                    if(p == null)
                    {
                        continue;
                    }
                    if (p.PropertyType == typeof(int))
                    {
                        p.SetValue(some, int.Parse(nameAndValue[1]), null);
                    }
                    else if (p.PropertyType == typeof(string))
                    {
                        p.SetValue(some, nameAndValue[1], null);
                    }
                    else if (p.PropertyType == typeof(decimal))
                    {
                        p.SetValue(some, decimal.Parse(nameAndValue[1]), null);
                    }
                    else if (p.PropertyType == typeof(char[]))
                    {
                        p.SetValue(some, nameAndValue[1].ToCharArray(), null);
                    }

                }
            }
            return some;
        }

        [SomeAttribute]
        static string ObjectToString(object o)
        {
            Type type = o.GetType();
            StringBuilder res = new StringBuilder();
            res.Append(type.AssemblyQualifiedName + ":");
            res.Append(type.Name + "|");
            var properties = type.GetProperties();
            foreach (var item in properties)
            {
                var prop = item.GetValue(o);
                res.Append(item.Name + ":");
                if(item.PropertyType == typeof(char[]))
                {
                    res.Append(new string(prop as char[]) + "|");
                }
                else
                {
                    res.Append(prop + "|");
                }
            }  
            return res.ToString();
        }

        static void Main(string[] args)
        {
            var n3 = MakeTestClass(10, "Some string", 777.777m, new char[] { '!', '@', '#', '$', '%', '^' });

            string s = ObjectToString(n3);
            Console.WriteLine(s);

            var s2 = StringToObject(s);
            Console.WriteLine(ObjectToString(s2));
        }
    }
}

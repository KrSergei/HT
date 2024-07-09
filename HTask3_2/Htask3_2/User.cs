
namespace Htask3_2
{
    internal class User //: IEquatable<User>
    {
        public User(string firstname, string lastname,int age)
        {
            FirstName = firstname;
            LastName = lastname;
            Age = age;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        //public bool Equals(User? other)
        //{
        //    if (other is null) return false;
        //    return FirstName.Equals(other.FirstName) && LastName.Equals(other.LastName) && Age == other.Age;
        //}
    }
}

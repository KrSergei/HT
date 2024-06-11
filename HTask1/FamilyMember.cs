namespace HTask1
{
    public enum Gender
    {
        male,
        female
    }
    public class FamilyMember    
    {        
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }       
        public Gender Gender { get; set; }
        public FamilyMember Mother { get; set; }
        public FamilyMember Father { get; set; }

        private List<FamilyMember> Children = new List<FamilyMember>();

        public FamilyMember[] GetGrandMothersName()
        {
            return new FamilyMember[] { Mother.Mother, Father.Mother };
        }

        public FamilyMember[] GetGrandFathersName()
        {
            return new FamilyMember[] { Mother.Father, Father.Father };
        }

        public void SetChildren(FamilyMember child)
        {
            Children.Add(child);
        }

        public List<FamilyMember> GetChildren()
        {
           return Children;
        }

        public int GetFullAge(DateTime birthday)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);
            TimeSpan timeSpan = DateTime.Now.Subtract(birthday);
            int age = (zeroTime + timeSpan).Year - 1;
            return age;
        }
    }

}

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
        public string SecondName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }       
        public Gender Gender { get; set; }
        public FamilyMember Mother { get; set; }
        public FamilyMember Father { get; set; }
        public FamilyMember Husband { get; set; }
        public FamilyMember Wife { get; set; }
        public FamilyMember Brother { get; set; }
        public FamilyMember Sister { get; set; }
    }

}

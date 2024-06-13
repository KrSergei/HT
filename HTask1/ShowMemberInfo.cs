namespace HTask1
{
    internal static class ShowMemberInfo
    {
        public static void PrintMemberInfo(FamilyMember familyMember)
        {
            Console.WriteLine($"Full name: - {familyMember.FirstName} {familyMember.MiddleName} {familyMember.SecondName}" +
                              $"\nborn in {familyMember.Birthday.ToString("dd.MM.yyyy")}");
        }

        public static void PrintMemberInfo(FamilyMember[] familyMember)
        {
            foreach (var item in familyMember)
            {
                Console.WriteLine($"Full name: - {item.FirstName} {item.MiddleName} {item.SecondName}" +
                                  $"\nborn in {item.Birthday.ToString("dd.MM.yyyy")}\n");
            }
        }

        public static void PrintMemberInfo(List<FamilyMember> familyMember)
        {
            if (familyMember != null)
            {
                foreach (var item in familyMember)
                {
                  Console.WriteLine($"Full name: - {item.FirstName} {item.MiddleName} {item.SecondName}" +
                                    $"\nborn in {item.Birthday.ToString("dd.MM.yyyy")}\n");
 
                }
            }
        }
    }
}

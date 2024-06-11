namespace HTask1
{
    internal static class ShowMemberInfo
    {
        public static void Print(FamilyMember familyMember)
        {
            Console.WriteLine($"Full name: - {familyMember.FirstName} {familyMember.MiddleName} {familyMember.SecondName}" +
                              $"\n born in {familyMember.Birthday.ToString("dd.MM.yyyy")}");
        }

        public static void Print(FamilyMember[] familyMember)
        {
            foreach (var item in familyMember)
            {
                Console.WriteLine($"Full name: - {item.FirstName} {item.MiddleName} {item.SecondName}" +
                                  $"\n born in {item.Birthday.ToString("dd.MM.yyyy")}\n");
            }
        }
    }
}

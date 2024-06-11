/*Генеалогическое дерево.
 * Учесть членов семьи с детьми и без детей
 */
using HTask1;

public class Program
{
    public static void Main(string[] args)
    {
        FamilyMember GrandFatherOne = new FamilyMember()
        {
            FirstName = "Ivan",
            SecondName = "Ivanov",
            MiddleName = "Ivanovich",
            Birthday = DateTime.Parse("25.05.1970"),
            Gender = Gender.male
        };

        FamilyMember GrandMotherOne = new FamilyMember()
        {
            FirstName = "Maria",
            SecondName = "Ivanova",
            MiddleName = "Ivanovna",
            Birthday = DateTime.Parse("15.07.1972"),
            Gender = Gender.female
        };

        FamilyMember GrandFatherSecond = new FamilyMember()
        {
            FirstName = "Yuriy",
            SecondName = "Vasiliev",
            MiddleName = "Stanislavovich",
            Birthday = DateTime.Parse("10.12.1969"),
            Gender = Gender.male
        };

        FamilyMember GrandMotherSecond = new FamilyMember()
        {
            FirstName = "Anna",
            SecondName = "Vasilieva",
            MiddleName = "Sergeevna",
            Birthday = DateTime.Parse("20.03.1971"),
            Gender = Gender.female
        };

        FamilyMember Father = new FamilyMember()
        {
            FirstName = "Dmitryi",
            SecondName = "Ivanov",
            MiddleName = "Ivanovich",
            Birthday = DateTime.Parse("15.09.1985"),
            Gender = Gender.male,
            Father = GrandFatherOne,
            Mother = GrandMotherOne
        };

        FamilyMember Mother = new FamilyMember()
        {
            FirstName = "Yuliya",
            SecondName = "Ivanova",
            MiddleName = "Yurivna",
            Birthday = DateTime.Parse("02.02.1987"),
            Gender = Gender.female,
            Father = GrandFatherSecond,
            Mother = GrandMotherSecond
        };

        FamilyMember OldSon = new FamilyMember()
        {
            FirstName = "Andrey",
            SecondName = "Ivanov",
            MiddleName = "Dmitrievich",
            Birthday = DateTime.Parse("04.03.2010"),
            Gender = Gender.male,
            Father = Father,
            Mother = Mother
        };

        FamilyMember OldDaugther = new FamilyMember()
        {
            FirstName = "Svetlana",
            SecondName = "Ivanova",
            MiddleName = "Dmitrievna",
            Birthday = DateTime.Parse("09.08.2012"),
            Gender = Gender.female,
            Father = Father,
            Mother = Mother
        };

        var GrandMothersOfSon = OldSon.GetGrandMothersName();
        ShowMemberInfo.PrintMemberInfo(GrandMothersOfSon);
    }
}

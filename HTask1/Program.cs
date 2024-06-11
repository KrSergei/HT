/*Генеалогическое дерево.
 * Учесть членов семьи с детьми и без детей
 */
using HTask1;
using System.Runtime.CompilerServices;

public class Program
{
    public static void Main(string[] args)
    {
        FamilyMember GrandFatherOne = new FamilyMember()
        {
            FirstName = "Ivan",
            LastName = "Ivanov",
            MiddleName = "Ivanovich",
            Birthday = DateTime.Parse("25.05.1970"),
            Gender = Gender.male
        };

        FamilyMember GrandMotherOne = new FamilyMember()
        {
            FirstName = "Maria",
            LastName = "Ivanova",
            MiddleName = "Ivanovna",
            Birthday = DateTime.Parse("15.07.1972"),
            Gender = Gender.female
        };

        FamilyMember GrandFatherSecond = new FamilyMember()
        {
            FirstName = "Yuriy",
            LastName = "Vasiliev",
            MiddleName = "Stanislavovich",
            Birthday = DateTime.Parse("10.12.1969"),
            Gender = Gender.male
        };

        FamilyMember GrandMotherSecond = new FamilyMember()
        {
            FirstName = "Anna",
            LastName = "Vasilieva",
            MiddleName = "Sergeevna",
            Birthday = DateTime.Parse("20.03.1971"),
            Gender = Gender.female
        };

        FamilyMember Father = new FamilyMember()
        {
            FirstName = "Dmitryi",
            LastName = "Ivanov",
            MiddleName = "Ivanovich",
            Birthday = DateTime.Parse("15.09.1985"),
            Gender = Gender.male,
            Father = GrandFatherOne,
            Mother = GrandMotherOne
        };

        FamilyMember Mother = new FamilyMember()
        {
            FirstName = "Yuliya",
            LastName = "Ivanova",
            MiddleName = "Yurivna",
            Birthday = DateTime.Parse("02.02.1987"),
            Gender = Gender.female,
            Father = GrandFatherSecond,
            Mother = GrandMotherSecond
        };

        FamilyMember OldSon = new FamilyMember()
        {
            FirstName = "Andrey",
            LastName = "Ivanov",
            MiddleName = "Dmitrievich",
            Birthday = DateTime.Parse("04.03.2010"),
            Gender = Gender.male,
            Father = Father,
            Mother = Mother
        };

        FamilyMember OldDaugther = new FamilyMember()
        {
            FirstName = "Svetlana",
            LastName = "Ivanova",
            MiddleName = "Dmitrievna",
            Birthday = DateTime.Parse("09.08.2012"),
            Gender = Gender.female,
            Father = Father,
            Mother = Mother
        };
    }
}

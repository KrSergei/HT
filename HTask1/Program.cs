/*Генеалогическое дерево.
 * Учесть членов семьи с детьми и без детей
 */
using HTask1;

public class Program
{
    public static void Main(string[] args)
    {
    #region Заполнение дданных членов семьи
        FamilyMember GrandFatherOne = new FamilyMember()
        {
            FirstName = "Ivan",
            SecondName = "Ivanov",
            MiddleName = "Ivanovich",
            Birthday = DateTime.Parse("25.05.1970"),
            Gender = Gender.male,
        };
        FamilyMemberInfoHandler.AddFamilyMember(GrandFatherOne);

        FamilyMember GrandMotherOne = new FamilyMember()
        {
            FirstName = "Maria",
            SecondName = "Ivanova",
            MiddleName = "Ivanovna",
            Birthday = DateTime.Parse("15.07.1972"),
            Gender = Gender.female
        };
        FamilyMemberInfoHandler.AddFamilyMember(GrandMotherOne);

        FamilyMember GrandFatherSecond = new FamilyMember()
        {
            FirstName = "Yuriy",
            SecondName = "Vasiliev",
            MiddleName = "Stanislavovich",
            Birthday = DateTime.Parse("10.12.1969"),
            Gender = Gender.male
        };
        FamilyMemberInfoHandler.AddFamilyMember(GrandFatherSecond);

        FamilyMember GrandMotherSecond = new FamilyMember()
        {
            FirstName = "Anna",
            SecondName = "Vasilieva",
            MiddleName = "Sergeevna",
            Birthday = DateTime.Parse("20.03.1971"),
            Gender = Gender.female
        };
        FamilyMemberInfoHandler.AddFamilyMember(GrandMotherSecond);

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
        FamilyMemberInfoHandler.AddFamilyMember(Father);

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
        FamilyMemberInfoHandler.AddFamilyMember(Mother);

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
        FamilyMemberInfoHandler.AddFamilyMember(OldSon);

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
        FamilyMemberInfoHandler.AddFamilyMember(OldDaugther);
        #endregion

    #region Обновление данных о наличии мужа и жены
        GrandFatherOne.Wife = GrandMotherOne;
        GrandMotherOne.Husband = GrandMotherOne;

        GrandFatherSecond.Wife = GrandMotherSecond;
        GrandMotherSecond.Husband = GrandFatherSecond;

        Father.Wife = Mother;
        Mother.Husband = Father;
        #endregion

        Console.WriteLine("GrandFathers");
        var GrandFathersOfSon = FamilyMemberInfoHandler.GetGrandFathersName(OldSon);
        ShowMemberInfo.PrintMemberInfo(GrandFathersOfSon);

        Console.WriteLine("GrandMothers");
        var GrandMothersOfDauther = FamilyMemberInfoHandler.GetGrandMothersName(OldDaugther);
        ShowMemberInfo.PrintMemberInfo(GrandMothersOfDauther);

        Console.WriteLine("Brothers and Sisters");
        var sistersAndbrothers = FamilyMemberInfoHandler.GetNameBrohersAndSisters(OldSon);
        ShowMemberInfo.PrintMemberInfo(sistersAndbrothers);

        Console.WriteLine("Spouse");
        var spouse = FamilyMemberInfoHandler.GetSpouse(Father);        
        ShowMemberInfo.PrintMemberInfo(spouse);
        Console.WriteLine("Spouse");
        spouse = FamilyMemberInfoHandler.GetSpouse(GrandFatherOne);
        ShowMemberInfo.PrintMemberInfo(spouse);
        Console.WriteLine("Spouse");
        spouse = FamilyMemberInfoHandler.GetSpouse(GrandMotherSecond);
        ShowMemberInfo.PrintMemberInfo(spouse);
    }
}

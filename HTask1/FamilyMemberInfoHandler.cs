using System.Collections.Generic;

namespace HTask1
{
    internal class FamilyMemberInfoHandler
    {
        FamilyMember FamilyMember = new FamilyMember();public static
        List<FamilyMember> listFamilyMembers = new List<FamilyMember>();

        public static void AddFamilyMember(FamilyMember familyMember)
        {
            listFamilyMembers.Add(familyMember);    
        }

        /// <summary>
        /// Поиск имен бабушек для указанного члена семьи
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static List<FamilyMember> GetGrandMothersName(FamilyMember member)
        {
            List<FamilyMember> grandMothers = new List<FamilyMember>();
            foreach (FamilyMember familyMember in listFamilyMembers)
            {
                if (familyMember == member)
                {
                    if(member.Mother.Mother != null) grandMothers.Add(familyMember.Mother.Mother);
                    if(member.Father.Mother != null) grandMothers.Add(familyMember.Father.Mother);
                }
            }
            return grandMothers;
        }

        /// <summary>
        /// Поис имен дедушек для указанного члена семьи
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static List<FamilyMember> GetGrandFathersName(FamilyMember member)
        {
            List<FamilyMember> grandFathers = new List<FamilyMember>();
            foreach (FamilyMember familyMember in listFamilyMembers)
            {
                if (familyMember == member)
                {
                    if (member.Mother.Father != null) grandFathers.Add(familyMember.Mother.Father);
                    if (member.Father.Father != null) grandFathers.Add(familyMember.Father.Father);
                }
            }
            return grandFathers;
        }

        /// <summary>
        /// Поиск имен для сетер и братьев по входящему брату или сестре
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static List<FamilyMember> GetNameBrohersAndSisters(FamilyMember member)
        {
            List<FamilyMember> nameBrothersSisters = new List<FamilyMember>();
            nameBrothersSisters.Add(member);
            foreach (FamilyMember familyMember in listFamilyMembers)
            {
                if (familyMember == member)
                {
                    foreach (FamilyMember mem in listFamilyMembers)
                    {
                        if (mem.Father == member.Father && mem != member) nameBrothersSisters.Add(mem);
                        else if (mem.Mother == member.Mother && mem != member) nameBrothersSisters.Add(mem);
                    }
                }
            }
            return nameBrothersSisters;
        }

        public static List<FamilyMember> GetSpouse(FamilyMember member)
        {
            List <FamilyMember> spouses = new List<FamilyMember>();
            spouses.Add(member);
            foreach (FamilyMember mem in listFamilyMembers)
            {
                if (mem == member && mem.Wife != null) spouses.Add(mem.Wife);
                else if (mem == member && mem.Husband != null) spouses.Add(mem.Husband);  
            }
            return spouses;
        }

        public static int GetFullAge(DateTime birthday)
        {
            DateTime zeroTime = new DateTime(1, 1, 1);
            TimeSpan timeSpan = DateTime.Now.Subtract(birthday);
            int age = (zeroTime + timeSpan).Year - 1;
            return age;
        }
    }
}

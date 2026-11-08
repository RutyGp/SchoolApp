using Model;
using ViewModel;

CityTbl c1 = new CityTbl() { CityName = "ירושלים", Id = 1 };
Console.WriteLine(c1);
CityDb cityDb = new CityDb();
CityTblList cities = cityDb.SelectAll();
foreach (CityTbl city in cities)
{
    Console.WriteLine(city);
}

Console.WriteLine(CityDb.SelectById(1));

PersonDb PersonDb = new PersonDb();
PersonTblList pList = PersonDb.SelectAll();
foreach (PersonTbl person in pList)
{
    Console.WriteLine(person);
}

Console.WriteLine(PersonDb.SelectById(1));

StudentTblList sList = StudentDB.list;
foreach (StudentTbl student in sList)
{
    Console.WriteLine(student);
}

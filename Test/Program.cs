using Model;
using ViewModel;

#region CityTbl
CityTbl c1 = new CityTbl() { CityName = "ירושלים", Id = 1 };
Console.WriteLine(c1);
CityDb cityDb = new CityDb();
CityTblList cities = cityDb.SelectAll();
foreach (CityTbl city in cities)
{
    Console.WriteLine(city);
}
CityTbl c = CityDb.SelectById(1);
c.CityName = "לא מוגדר";
cityDb.Update(c);
cityDb.SaveChanges();



#endregion

#region PersonTbl
Console.WriteLine(CityDb.SelectById(1));

PersonDb PersonDb = new PersonDb();
PersonTblList pList = PersonDb.SelectAll();
foreach (PersonTbl person in pList)
{
    Console.WriteLine(person);
}

Console.WriteLine(PersonDb.SelectById(1));

PersonTbl person1 = PersonDb.SelectById(1);
person1.FirstName = "משה";
person1.IsActive = false;
person1.LastName = "לוי";
PersonDb.Update(person1);
PersonDb.SaveChanges();


#endregion

#region StudentTbl
StudentTblList sList = StudentDB.list;
foreach (StudentTbl student in sList)
{
    Console.WriteLine(student);
}
StudentDB student1 = new StudentDB();
StudentTbl s= student1.SelectAll().First();



s.Tel= "050-1234567";
s.LastName = "כהן";
student1.Update(s);
student1.SaveChanges();
#endregion
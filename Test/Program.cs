using Model;
using ViewModel;
#region 1
//CityTbl c1 = new CityTbl() { CityName = "ירושלים", Id = 1 };
//Console.WriteLine(c1);
//CityDb cityDb = new CityDb();
//CityTblList cities = cityDb.SelectAll();
//foreach (CityTbl city in cities)
//{
//    Console.WriteLine(city);
//}
//cities[0].CityName = "תל -- אביב";
//cityDb.Update(cities[0]);
//cityDb.SaveChanges();
//Console.WriteLine(CityDb.SelectById(1));

//PersonDb personDb = new PersonDb();
//PersonTblList pList = personDb.SelectAll();
//foreach (PersonTbl person in pList)
//{
//    Console.WriteLine(person);
//}
//pList[0].FirstName= "עודד";
//personDb.Update(pList[0]);
//personDb.SaveChanges();

//Console.WriteLine(PersonDb.SelectById(1));


//StudentTblList sList = StudentDB.list;
//sList[0].Tel = "050-1234567";
//StudentDB studentDb = new StudentDB();
//studentDb.Update(sList[0]);
//studentDb.SaveChanges();
//foreach (StudentTbl student in sList)
//{
//    Console.WriteLine(student);
//}
#endregion 1
#region 2
TeacherDB dB = new TeacherDB();
TeacherTblList tList=dB.SelectAll();
tList[1].IsEducator = false;
tList[1].IsActive = true;
tList[1].StartWorkingDate = DateTime.Now.AddDays(+2);
dB.Update(tList[1]);
dB.SaveChanges();
#endregion 2
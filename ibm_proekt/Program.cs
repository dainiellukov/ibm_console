using ibm_proekt;
using ibm_proekt.Data;
using ibm_proekt.Data.Models;
Console.WriteLine("Database information:");
using (IbmContext db = new IbmContext())

{

    bool isCreated = db.Database.EnsureCreated();

    // bool isCreated2 = await db.Database.EnsureCreatedAsync(); 

    if (isCreated) Console.WriteLine("The database has been created.");

    else Console.WriteLine("The database already exist.");

}
using (IbmContext db = new IbmContext())

{

    bool isAvalaible = db.Database.CanConnect();

    // bool isAvalaible2 = await db.Database.CanConnectAsync(); 

    if (isAvalaible) Console.WriteLine("The database is connected and available.");

    else Console.WriteLine("The database isn't connectd.");

}
using (IbmContext db = new IbmContext())

{

    

    var users = db.Firmis.ToList();

    Console.WriteLine("List of firms");

    foreach (Firmi u in users)

    {

        Console.WriteLine($"{u.FirmaId} - {u.FirmaIme}");

    }

}
// Добавяне 

using (IbmContext db = new IbmContext())

{

    Marshruti marshrutKVT = new Marshruti { ZaminavaOt = "Kazanlak", ZaminavaZa = "Veliko Turnovo", ZaminavaChas = TimeOnly.Parse("22:20:00"), PristigaChas = TimeOnly.Parse("23:50:00") };

    



    // Добавяне 

    db.Marshrutis.Add(marshrutKVT);

    db.SaveChanges();

}



// Четене 

using (IbmContext db = new IbmContext())

{



    var marshrutiList = db.Marshrutis.ToList();

    Console.WriteLine("List of marshruti");

    foreach (Marshruti u in marshrutiList)

    {

        Console.WriteLine($"{u.MarshrutId} - {u.ZaminavaZa} - {u.ZaminavaOt} - {u.ZaminavaChas} - {u.PristigaChas}");

    }

}



// Редактирование 

using (IbmContext db = new IbmContext())

{

    // получаем первый объект 

    Marshruti? marshrut = db.Marshrutis.FirstOrDefault();

    if (marshrut != null)

    {

        marshrut.ZaminavaOt = "Sofiq";

        marshrut.PristigaChas = TimeOnly.Parse("15:30:00");

        //обновляем объект 

        //db.Users.Update(user); 

        db.SaveChanges();

    }

    // выводим данные после обновления 

    Console.WriteLine("\nData after changes:");

    var users = db.Marshrutis.ToList();

    foreach (Marshruti u in users)

    {

        Console.WriteLine($"{u.MarshrutId}.{u.ZaminavaOt} - {u.ZaminavaZa}");

    }

}



// Удаление 

using (IbmContext db = new IbmContext())

{

    // получаем первый объект 

    var users = db.Marshrutis.ToList();

    foreach (Marshruti u in users)
    {
        if(u.MarshrutId == 11)
        {
            db.Marshrutis.Remove(u);

            db.SaveChanges();
        }
    }

    // выводим данные после обновления 

    Console.WriteLine("\nData after removal:");

    var marshruts = db.Marshrutis.ToList();

    foreach (Marshruti u in marshruts)

    {

        Console.WriteLine($"{u.MarshrutId}");

    }

}
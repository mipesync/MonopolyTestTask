using MonopolyTestTask.Models;

var pallets = GenerateData();

var groupedPallets = pallets
    .Where(p => p.GetExpirationDate().HasValue)
    .OrderBy(p => p.GetExpirationDate())
    .ThenBy(p => p.GetTotalWeight())
    .GroupBy(p => p.GetExpirationDate())
    .ToList();

Console.WriteLine("Группировка по сроку годности:");
foreach (var group in groupedPallets)
{
    Console.WriteLine($"Группа со сроком годности: {group.First().GetExpirationDate():dd.MM.yyyy}");
    foreach (var pallet in group)
    {
        Console.WriteLine($"Id паллеты: {pallet.Id}, Вес: {pallet.GetTotalWeight()}, Объем: {pallet.GetVolume()}");
    }
}

var maxExpDatePallets = pallets
    .Where(p => p.Boxes.Count != 0)
    .OrderByDescending(p => p.Boxes.Max(b => b.ExpirationDate))
    .ThenBy(p => p.GetVolume())
    .Take(3)
    .ToList();

Console.WriteLine("\n3 паллеты с наибольшим сроком годности:");
foreach (var pallet in maxExpDatePallets)
{
    Console.WriteLine($"Id паллеты: {pallet.Id}, Срок годности: {pallet.GetExpirationDate():dd.MM.yyyy}, Объем: {pallet.GetVolume()}");
}
return;

List<Pallet> GenerateData()
{
    var pallet1 = new Pallet(120, 80, 150);
    var pallet2 = new Pallet(100, 80, 120);
    var pallet3 = new Pallet(130, 90, 160);
    var pallet4 = new Pallet(140, 100, 170);

    pallet1.AddBox(new Box(50, 50, 50, 10, DateTime.Now.AddDays(50))); 
    pallet1.AddBox(new Box(30, 40, 40, 8, productionDate: DateTime.Now.AddDays(-10)));
    pallet1.AddBox(new Box(20, 30, 30, 5, DateTime.Now.AddDays(90))); 
    pallet1.AddBox(new Box(40, 40, 40, 7, productionDate: DateTime.Now.AddDays(-20)));
    pallet1.AddBox(new Box(30, 30, 30, 6, DateTime.Now.AddDays(60))); 
   
    pallet2.AddBox(new Box(40, 60, 40, 12, productionDate: DateTime.Now.AddDays(-30)));
    pallet2.AddBox(new Box(50, 50, 50, 15, DateTime.Now.AddDays(20))); 
    pallet2.AddBox(new Box(60, 60, 60, 20, DateTime.Now.AddDays(120)));
    pallet2.AddBox(new Box(25, 35, 35, 10, DateTime.Now.AddDays(70))); 
   
    pallet3.AddBox(new Box(60, 60, 60, 20, productionDate: DateTime.Now.AddDays(-40)));
    pallet3.AddBox(new Box(45, 45, 45, 13, DateTime.Now.AddDays(10)));  
    pallet3.AddBox(new Box(30, 30, 30, 5, DateTime.Now.AddDays(60)));   
    pallet3.AddBox(new Box(35, 45, 45, 9, DateTime.Now.AddDays(30)));   
    pallet3.AddBox(new Box(50, 50, 50, 15, productionDate: DateTime.Now.AddDays(-60)));
   
    pallet4.AddBox(new Box(70, 70, 70, 25, DateTime.Now.AddDays(90)));  
    pallet4.AddBox(new Box(80, 60, 50, 18, productionDate: DateTime.Now.AddDays(-50)));
    pallet4.AddBox(new Box(40, 40, 40, 12, DateTime.Now.AddDays(150))); 
    pallet4.AddBox(new Box(30, 30, 30, 10, DateTime.Now.AddDays(200))); 
    pallet4.AddBox(new Box(20, 20, 20, 8, productionDate: DateTime.Now.AddDays(-100)));

    return [pallet1, pallet2, pallet3, pallet4];
}
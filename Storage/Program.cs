using Storage.DataGenerator;
using Storage.Factories;

class Program
{
    static void Main()
    {
        IBoxFactory boxFactory = new BoxFactory();
        IPalletDataGenerator palletDataGenerator = new PalletDataGenerator(boxFactory);

        var pallets = palletDataGenerator.GeneratePallets(10);

        Console.WriteLine("Группировка паллет по сроку годности, отсортированные по возрастанию, сортировка внутри группы по весу");
        var grouped = pallets
            .GroupBy(p => p.ExpirationDate)
            .OrderBy(g => g.Key)
            .Select(g => new
            {
                ExpirationDate = g.Key,
                Pallets = g.OrderBy(p => p.Weight)
            });

        foreach (var group in grouped)
        {
            Console.WriteLine($"Срок годности: {group.ExpirationDate:d}");
            foreach (var pallet in group.Pallets)
            {
                Console.WriteLine($"  ID: {pallet.Id} | Вес: {pallet.Weight:F2}kg | Количество коробок: {pallet.Boxes.Count} | Объем: {pallet.Volume:F2}");
            }
        }

        Console.WriteLine("\n\n3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема:");
        var searchedPallets = pallets
            .Where(p => p.Boxes.Any())
            .OrderByDescending(p => p.Boxes.Max(b => b.ExpirationDate))
            .Take(3)
            .OrderBy(p => p.Volume);

        foreach (var pallet in searchedPallets)
        {
            var maxBoxExpDate = pallet.Boxes.Max(b => b.ExpirationDate);
            Console.WriteLine($"ID: {pallet.Id} | Максимальный срок годности одной из коробок: {maxBoxExpDate:d} | Объем: {pallet.Volume:F2} | Вес: {pallet.Weight:F2} | Количество коробок: {pallet.Boxes.Count}");
        }
    }
}
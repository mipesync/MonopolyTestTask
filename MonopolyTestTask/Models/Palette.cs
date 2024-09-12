namespace MonopolyTestTask.Models;

/// <summary>
/// Класс паллеты
/// </summary>
public class Pallet : BaseProperties
{
    private const int BaseWeight = 30;
    public ICollection<Box> Boxes { get; } = new List<Box>();
    
    public Pallet(double width, double height, double depth) : base(width, height, depth, BaseWeight) { }

    public override double GetVolume()
    {
        return Boxes.Sum(box => box.GetVolume()) + (Width * Height * Depth);
    }
    
    /// <summary>
    /// Добавить коробку
    /// </summary>
    /// <exception cref="ArgumentException">Габариты коробки больше габаритов паллеты</exception>
    public void AddBox(Box box)
    {
        if (box.Width > Width || box.Depth > Depth)
            throw new ArgumentException("Габариты коробки больше габаритов паллеты");
        
        Boxes.Add(box);
    }

    /// <summary>
    /// Получить срок годности паллеты
    /// </summary>
    /// <returns></returns>
    public DateTime? GetExpirationDate()
    {
        return Boxes.Count > 0 ? Boxes.Min(box => box.ExpirationDate) : null;
    }

    /// <summary>
    /// Получить итоговый вес паллеты
    /// </summary>
    /// <returns></returns>
    public double GetTotalWeight()
    {
        return BaseWeight + Boxes.Sum(box => box.Weight);
    }
}
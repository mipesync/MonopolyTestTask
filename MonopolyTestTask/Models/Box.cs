namespace MonopolyTestTask.Models;

/// <summary>
/// Класс коробки
/// </summary>
public class Box : BaseProperties
{
    public DateTime? ExpirationDate { get; }
    public DateTime? ProductionDate { get; }

    public Box(double width, double height, double depth, double weight, DateTime? expirationDate = null, DateTime? productionDate = null)
        : base(width, height, depth, weight)
    {
        if (expirationDate.HasValue)
        {
            ExpirationDate = expirationDate;
        }
        else if (productionDate.HasValue)
        {
            ProductionDate = productionDate;
            ExpirationDate = ProductionDate.Value.AddDays(100);
        }
    }
    
    public override double GetVolume()
    {
        return Width * Height * Depth;
    }
}
namespace MonopolyTestTask.Models;

/// <summary>
/// Класс с базовыми свойствами
/// </summary>
public abstract class BaseProperties
{
    public Guid Id { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double Weight { get; set; }

    public BaseProperties(double width, double height, double depth, double weight)
    {
        Id = Guid.NewGuid();
        Width = width;
        Height = height;
        Depth = depth;
        Weight = weight;
    }
    
    /// <summary>
    /// Получить объём
    /// </summary>
    public abstract double GetVolume();
}
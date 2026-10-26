namespace CoffeeGo.Core.Menu;

public enum CupSize
{
    Small,
    Medium,
    Large
}

public class MenuItem
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public decimal BasePrice { get; init; }
    public bool IsAvailable { get; set; } = true;
}

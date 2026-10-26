namespace CoffeeGo.Core.Menu;

/// <summary>
/// Розраховує ціну напою з урахуванням розміру чашки та добавок (FR-002, FR-003).
/// </summary>
public class PriceCalculator
{
    public const decimal ExtraPrice = 15m;

    private static readonly IReadOnlyDictionary<CupSize, decimal> SizeMultipliers =
        new Dictionary<CupSize, decimal>
        {
            [CupSize.Small] = 1.0m,
            [CupSize.Medium] = 1.2m,
            [CupSize.Large] = 1.4m
        };

    public decimal CalculatePrice(MenuItem item, CupSize size, int extrasCount)
    {
        ArgumentNullException.ThrowIfNull(item);

        if (!item.IsAvailable)
            throw new InvalidOperationException($"Позиція «{item.Name}» зараз недоступна");

        if (extrasCount < 0)
            throw new ArgumentOutOfRangeException(nameof(extrasCount), "Кількість добавок не може бути від'ємною");

        var price = item.BasePrice * SizeMultipliers[size] + extrasCount * ExtraPrice;
        return Math.Round(price, 2, MidpointRounding.AwayFromZero);
    }
}

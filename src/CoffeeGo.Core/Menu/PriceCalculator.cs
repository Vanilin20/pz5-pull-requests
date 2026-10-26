namespace CoffeeGo.Core.Menu;

public class PriceCalculator
{
    public double Calc(MenuItem item, CupSize size, int extras)
    {
        double k = 1.0;
        if (size == CupSize.Medium) k = 1.2;
        if (size == CupSize.Large) k = 1.4;

        return item.BasePrice * k + extras * 15;
    }
}

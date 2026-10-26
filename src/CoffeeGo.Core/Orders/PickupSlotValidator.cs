namespace CoffeeGo.Core.Orders;

/// <summary>
/// Перевіряє час отримання замовлення (FR-003): не раніше ніж через 10 хв від оформлення,
/// не пізніше ніж за 15 хв до закриття і рівно на початку 10-хвилинного слоту.
/// </summary>
public class PickupSlotValidator
{
    public static readonly TimeSpan MinLeadTime = TimeSpan.FromMinutes(10);
    public static readonly TimeSpan LastPickupBeforeClosing = TimeSpan.FromMinutes(15);
    public const int SlotLengthMinutes = 10;

    public bool IsValid(DateTime pickupTime, DateTime now, DateTime cafeClosingTime)
    {
        if (pickupTime < now + MinLeadTime)
            return false;

        if (pickupTime > cafeClosingTime - LastPickupBeforeClosing)
            return false;

        return pickupTime.Minute % SlotLengthMinutes == 0 && pickupTime.Second == 0;
    }
}

namespace CoffeeGo.Core.Orders;

public class PickupSlotValidator
{
    public bool IsValid(DateTime pickupTime, DateTime cafeClosingTime)
    {
        if (pickupTime < DateTime.Now.AddMinutes(10))
            return false;

        if (pickupTime > cafeClosingTime.AddMinutes(-15))
            return false;

        return pickupTime.Minute % 10 == 0;
    }
}

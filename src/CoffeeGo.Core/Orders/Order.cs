namespace CoffeeGo.Core.Orders;

public enum OrderStatus
{
    Accepted,
    Preparing,
    Ready,
    Issued,
    Cancelled
}

public class Order
{
    public int Id { get; init; }
    public string CustomerPhone { get; init; } = string.Empty;
    public int CafeId { get; init; }
    public DateTime PickupTime { get; init; }
    public OrderStatus Status { get; private set; } = OrderStatus.Accepted;

    public void MoveToNextStatus()
    {
        Status = Status switch
        {
            OrderStatus.Accepted => OrderStatus.Preparing,
            OrderStatus.Preparing => OrderStatus.Ready,
            OrderStatus.Ready => OrderStatus.Issued,
            _ => throw new InvalidOperationException($"Замовлення у статусі {Status} не можна перевести далі")
        };
    }

    public void Cancel()
    {
        if (Status != OrderStatus.Accepted)
            throw new InvalidOperationException("Скасувати можна лише замовлення, яке ще не почали готувати");

        Status = OrderStatus.Cancelled;
    }
}

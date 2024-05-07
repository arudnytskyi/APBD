using tut6.Model;

namespace tut6.Repository;

public interface IOrderRepository
{
    public Order HasValidPurchaseOrder(int productId, int amount, DateTime createdAt);

    public bool IsOrderCompleted(int orderId);

    public void UpdateOrderFulfilledDate(int orderId);
}
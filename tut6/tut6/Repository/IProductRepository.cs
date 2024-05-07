using tut6.Model;

namespace tut6.Repository;

public interface IProductRepository
{
    public Product ProductExists(int productId);
}
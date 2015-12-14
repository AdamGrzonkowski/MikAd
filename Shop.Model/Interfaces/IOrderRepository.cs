using Shop.Model.Models;

namespace Shop.Model.Interfaces
{
    interface IOrderRepository : IRepository<Order, int>
    {
    }
}

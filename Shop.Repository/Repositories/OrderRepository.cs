using System.Linq;
using Shop.Model.Interfaces;
using Shop.Model.Models;

namespace Shop.Model.Repositories
{
    public class OrderRepository : IOrderRepository

    {
        private ShopContext _shopContext;

        public OrderRepository()
        {
            _shopContext = new ShopContext();
        }

        public void Dispose()
        {
            _shopContext.Dispose();
        }

        public IQueryable<Order> GetAll()
        {
            return _shopContext.Orders;
        }

        public Order GetById(int id)
        {
            return _shopContext.Orders.SingleOrDefault(x => x.Id == id);
        }

        public int Add(Order entity)
        {
            entity.TotalPrice = entity.Transactions.Sum(x => x.Product.Price);
            _shopContext.Orders.Add(entity);
            _shopContext.SaveChanges();

            return entity.Id;
        }

        public void Update(int id, Order entity)
        {
            Order dbOrder = GetById(id);
            dbOrder.SendDate = entity.SendDate;
            dbOrder.Transactions = entity.Transactions;
            dbOrder.IsPaid = entity.IsPaid;
            dbOrder.IsSent = entity.IsSent;
            dbOrder.Transactions = entity.Transactions;
            dbOrder.TotalPrice = entity.Transactions.Sum(x => x.Product.Price);
            _shopContext.SaveChanges();
        }

        public void Delete(Order entity)
        {
            _shopContext.Orders.Remove(entity);
        }

        public void Delete(int id)
        {
            Order entity = GetById(id);
            _shopContext.Orders.Remove(entity);
        }
    }
}
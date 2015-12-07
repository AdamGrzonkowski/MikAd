using System.Linq;
using Shop.Model.Interfaces;
using Shop.Model.Models;

namespace Shop.Model.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private ShopContext _shopContext ;

        public BasketRepository()
        {
            _shopContext = new ShopContext();
        }

        public void Dispose()
        {
            _shopContext.Dispose();
        }

        public IQueryable<Basket> GetAll()
        {
            return _shopContext.Baskets;
        }

        public Basket GetById(int id)
        {
            return _shopContext.Baskets.SingleOrDefault(x => x.Id == id);
        }

        public int Add(Basket entity)
        {
            _shopContext.Baskets.Add(entity);
            _shopContext.SaveChanges();

            return entity.Id;
        }

        public void Update(int id, Basket entity)
        {
            Basket dbBasket = GetById(id);
            dbBasket.Amount = entity.Amount;
            _shopContext.SaveChanges();
        }

        public void Delete(Basket entity)
        {
            _shopContext.Baskets.Remove(entity);
        }

        public void Delete(int id)
        {
            Basket entity = GetById(id);
            _shopContext.Baskets.Remove(entity);
        }
    }
}
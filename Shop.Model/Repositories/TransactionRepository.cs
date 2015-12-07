using System.Linq;
using Shop.Model.Interfaces;
using Shop.Model.Models;

namespace Shop.Model.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ShopContext _shopContext;

        public TransactionRepository()
        {
            _shopContext = new ShopContext();
        }

        public void Dispose()
        {
            _shopContext.Dispose();
        }

        public IQueryable<Transaction> GetAll()
        {
            return _shopContext.Transactions;
        }

        public Transaction GetById(int id)
        {
            return _shopContext.Transactions.SingleOrDefault(x => x.Id == id);
        }

        public int Add(Transaction entity)
        {
            _shopContext.Transactions.Add(entity);
            _shopContext.SaveChanges();

            return entity.Id;
        }

        public void Update(int id, Transaction entity)
        {
            Transaction dbTransaction = GetById(id);
            dbTransaction.Amount = entity.Amount;
        }

        public void Delete(Transaction entity)
        {
            _shopContext.Transactions.Remove(entity);
        }

        public void Delete(int id)
        {
            Transaction entity = GetById(id);
            _shopContext.Transactions.Remove(entity);
        }
    }
}
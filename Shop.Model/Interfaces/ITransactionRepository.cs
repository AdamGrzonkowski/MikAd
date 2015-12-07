using Shop.Model.Models;

namespace Shop.Model.Interfaces
{
    interface ITransactionRepository : IRepository<Transaction, int>
    {
    }
}

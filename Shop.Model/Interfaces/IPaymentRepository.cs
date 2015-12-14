using Shop.Model.Models;

namespace Shop.Model.Interfaces
{
    interface IPaymentRepository : IRepository<Payment, int>
    {
    }
}

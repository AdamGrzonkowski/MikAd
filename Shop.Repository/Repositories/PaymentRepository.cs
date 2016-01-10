using Shop.DataEntry;
using Shop.Model.Models;
using Shop.Repository.Interfaces;

namespace Shop.Repository.Repositories
{
    public class PaymentRepository : Repository<Payment, int>, IPaymentRepository
    {
        public PaymentRepository(ShopContext context) : base(context)
        {
        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }
    }
}

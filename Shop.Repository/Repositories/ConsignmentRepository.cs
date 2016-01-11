using Shop.DataEntry;
using Shop.Model.Models;
using Shop.Repository.Interfaces;

namespace Shop.Repository.Repositories
{
    public class ConsignmentRepository : Repository<Consignment, int>, IConsignmentRepository
    {
        public ConsignmentRepository(ShopContext context) : base(context)
        {
        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }
    }
}

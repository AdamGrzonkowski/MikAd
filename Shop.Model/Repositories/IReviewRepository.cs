using System.Linq;
using Shop.Model.Models;

namespace Shop.Model.Repositories
{
    interface IReviewRepository : IRepository<Review, int>
    {
        IQueryable<Review> GetByRate(int rate);
    }
}

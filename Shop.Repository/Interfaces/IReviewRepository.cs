using System.Linq;
using Shop.Model.Models;

namespace Shop.Repository.Interfaces
{
    interface IReviewRepository : IRepository<Review, int>
    {
        IQueryable<Review> GetByRate(int rate);
    }
}

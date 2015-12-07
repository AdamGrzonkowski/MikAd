using System.Linq;
using Shop.Model.Models;
using Shop.Model.Interfaces;

namespace Shop.Model.Interfaces
{
    interface IReviewRepository : IRepository<Review, int>
    {
        IQueryable<Review> GetByRate(int rate);
    }
}

using System.Linq;
using Shop.Model.Models;

namespace Shop.Model.Repositories
{
    class ReviewRepository : IReviewRepository
    {
        private readonly ShopContext _shopContext;

        public ReviewRepository()
        {
            _shopContext = new ShopContext();
        }

        public void Dispose()
        {
            _shopContext.Dispose();
        }

        public IQueryable<Review> GetAll()
        {
            return _shopContext.Reviews;
        }

        public Review GetById(int id)
        {
            return _shopContext.Reviews.SingleOrDefault(x => x.Id == id);
        }

        public int Add(Review entity)
        {
            _shopContext.Reviews.Add(entity);
            _shopContext.SaveChanges();

            return entity.Id;
        }

        public void Update(int id, Review entity)
        {
            Review dbReview = GetById(id);
            dbReview.ReviewText = entity.ReviewText;
            dbReview.Rate = entity.Rate;
            _shopContext.SaveChanges();
        }

        public void Delete(Review entity)
        {
            _shopContext.Reviews.Remove(entity);
        }
        
        public void Delete(int id)
        {
            Review dbReview = GetById(id);
            _shopContext.Reviews.Remove(dbReview);
        }

        public IQueryable<Review> GetByRate(int rate)
        {
            return from review in _shopContext.Reviews
                where review.Rate == (Rate)(rate)
                   select review;
        }
    }
}
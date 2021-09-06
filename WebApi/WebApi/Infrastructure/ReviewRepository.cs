using WebApi.Entities;

namespace WebApi.Infrastructure
{
    public class ReviewRepository
    {
        private readonly MovieApiDbContext _context;

        public ReviewRepository( MovieApiDbContext context )
        {
            _context = context;
        }
        
        public void AddReview( Review review )
        {
            _context.Reviews.Add( review );
        }
    }
}
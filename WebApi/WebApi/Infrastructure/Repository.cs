namespace WebApi.Infrastructure
{
    public class Repository
    {
        private readonly MovieApiDbContext _context;

        public Repository( MovieRepository movies, ReviewRepository reviews, MovieApiDbContext context )
        {
            _context = context;
            Movies = movies;
            Reviews = reviews;
        }
        
        public MovieRepository Movies { get; }
        public ReviewRepository Reviews { get; }

        public void Save( )
        {
            _context.SaveChanges( );
        }
    }
}
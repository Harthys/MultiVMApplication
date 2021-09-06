using WebApi.Entities;

namespace WebApi.Controllers.Responses
{
    public class MovieSummary
    {
        public MovieSummary( Movie movie )
        {
            Id = movie.Id;
            Title = movie.Title;
            DescriptionBody = movie.DescriptionBody;
            AverageRating = movie.AverageRating;
        }
        
        public int Id { get; }
        public string Title { get; }
        public string DescriptionBody { get; }
        public double AverageRating { get; }
    }
}
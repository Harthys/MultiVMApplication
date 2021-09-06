using System;

namespace WebApi.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public double Rating { get; private set; }
        public string Title { get; set; }
        public string Body { get; set; }
        
        public virtual Movie Movie { get; set; }

        /// <summary>
        /// Enforces 1 decimal point rounding for all Review Ratings
        /// </summary>
        public void SetRating( double rating )
        {
            Rating = Math.Round( rating, 1, MidpointRounding.AwayFromZero );
        }
    }
}
using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers.Requests
{
    public class CreateReviewRequest
    {
        public int MovieId { get; set; }
        public double Rating { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public List<string> Validate( )
        {
            var errors = new List<string>( );

            if ( Rating < 1 || Rating > 10 )
            {
                errors.Add( $"{nameof( Rating )} must be between 1-10." );
            }

            if ( string.IsNullOrWhiteSpace( Title ) )
            {
                errors.Add( $"{nameof( Title )} must be populated." );
            }

            if ( string.IsNullOrWhiteSpace( Body ) )
            {
                errors.Add( $"{nameof( Body )} must be populated." );
            }

            return errors;
        }

        public Review ToReview( )
        {
            var review = new Review
            {
                MovieId = MovieId,
                Title = Title,
                Body = Body
            };

            review.SetRating( Rating );

            return review;
        }
    }
}
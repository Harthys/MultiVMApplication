using System.Collections.Generic;
using WebApi.Entities;
using WebApi.Infrastructure;

namespace WebApi.Validation
{
    public class ReviewValidationService
    {
        private readonly Repository _repository;

        public ReviewValidationService( Repository repository )
        {
            _repository = repository;
        }

        public List<string> Validate( Review review )
        {
            var errors = new List<string>( );
            
            var movie = _repository.Movies.GetMovieById( review.MovieId );

            if ( movie == null )
            {
                errors.Add( $"{nameof( review.MovieId )} must be belong to a valid movie." );
            }

            return errors;
        }
    }
}
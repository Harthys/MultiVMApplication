using System.Collections.Generic;
using WebApi.Entities;

namespace WebApi.Controllers.Requests
{
    public class CreateMovieRequest
    {
        public string Title { get; set; }
        public string DescriptionBody { get; set; }

        public List<string> Validate( )
        {
            var errors = new List<string>( );

            if ( string.IsNullOrWhiteSpace( Title ) )
            {
                errors.Add( $"{nameof( Title )} must be populated." );
            }
            
            if ( string.IsNullOrWhiteSpace( DescriptionBody ) )
            {
                errors.Add( $"{nameof( DescriptionBody )} must be populated." );
            }

            return errors;
        }

        public Movie ToMovie( )
        {
            return new()
            {
                Title = Title,
                DescriptionBody = DescriptionBody
            };
        }
    }
}
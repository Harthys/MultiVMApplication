using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string DescriptionBody { get; set; }
        public double AverageRating => GetAverageRating( );
        
        public virtual List<Review> Reviews { get; set; }

        private double GetAverageRating( )
        {
            if ( !Reviews.Any( ) )
            {
                return 0;
            }

            return Math.Round( Reviews.Average( x => x.Rating ), 1, MidpointRounding.ToEven );
        }
    }
}
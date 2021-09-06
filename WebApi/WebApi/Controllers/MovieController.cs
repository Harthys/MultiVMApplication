using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Requests;
using WebApi.Controllers.Responses;
using WebApi.Infrastructure;

namespace WebApi.Controllers
{
    public class MovieController : ApiControllerBase
    {
        private readonly Repository _repository;

        public MovieController( Repository repository )
        {
            _repository = repository;
        }

        [HttpGet]
        public List<MovieSummary> Index( )
        {
            var movies = _repository.Movies.GetMovies( );

            return movies
                .Select( x => new MovieSummary( x ) )
                .ToList( );
        }

        [HttpGet( "{id}" )]
        public IActionResult GetById( int id )
        {
            var movie = _repository.Movies.GetMovieById( id );
            if ( movie == null )
            {
                return BadRequest( "The requested movie could not be found." );
            }

            return Ok( movie );
        }

        [HttpPost]
        public IActionResult Create( CreateMovieRequest request )
        {
            var errors = request.Validate( );

            if ( errors.Any( ) )
            {
                return BadRequest( errors );
            }

            var movie = request.ToMovie( );

            _repository.Movies.AddMovie( movie );
            _repository.Save( );

            return Ok( movie.Id );
        }
    }
}
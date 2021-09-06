using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Requests;
using WebApi.Infrastructure;
using WebApi.Validation;

namespace WebApi.Controllers
{
    public class ReviewController : ApiControllerBase
    {
        private readonly Repository _repository;
        private readonly ReviewValidationService _reviewValidationService;

        public ReviewController( Repository repository, ReviewValidationService reviewValidationService )
        {
            _repository = repository;
            _reviewValidationService = reviewValidationService;
        }

        [HttpPost]
        public IActionResult Create( CreateReviewRequest request )
        {
            // Validate request
            var requestValidationErrors = request.Validate( );

            if ( requestValidationErrors.Any( ) )
            {
                return BadRequest( requestValidationErrors );
            }

            var review = request.ToReview( );

            // Validate Review object
            var validationErrors = _reviewValidationService.Validate( review );
            if ( validationErrors.Any( ) )
            {
                return BadRequest( validationErrors );
            }

            _repository.Reviews.AddReview( review );
            _repository.Save( );

            return Ok( review.Id );
        }
    }
}
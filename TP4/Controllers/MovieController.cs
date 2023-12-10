using Microsoft.AspNetCore.Mvc;
using TP4.Services.Services;
using System;

namespace TP4.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService ?? throw new ArgumentNullException(nameof(movieService));
        }

        public IActionResult Index()
        {
            var movies = _movieService._repository.GetAllMovies();
            return View(movies);
        }

        // Route for listing movies associated with a genre defined by the user
        [HttpGet("/movies/genre/{userDefinedGenre}")]
        public IActionResult GetMoviesByUserDefinedGenre(int userDefinedGenre)
        {
            var movies = _movieService._repository.GetMoviesByUserDefinedGenre(userDefinedGenre);
            return View("Index", movies);
            // Assuming "Index" is the name of your view for listing movies.
        }

        // Route for listing all movies ordered in ascending order
        [HttpGet("/movies/ordered")]
        public IActionResult GetAllMoviesOrderedByAscending()
        {
            var movies = _movieService._repository.GetAllMoviesOrderedByAscending();
            return View("Index", movies);
            // Assuming "Index" is the name of your view for listing movies.
        }

        // Route for retrieving movies by their genre ID
        [HttpGet("/movies/genreId/{genreId}")]
        public IActionResult GetMoviesByGenreId(int genreId)
        {
            var movies = _movieService._repository.GetMoviesByGenreId(genreId);
            return View("Index", movies);
            // Assuming "Index" is the name of your view for listing movies.
        }
    }
}

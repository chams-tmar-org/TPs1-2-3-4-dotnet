using ASPCoreApplication2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ASPCoreApplication2023.Services;


namespace AspCoreApplication2023.Controllers
{
    public class MovieController : Controller
    {
        /*private readonly ApplicationDbContext _db;
        public MovieController(ApplicationDbContext db)
        {
            _db = db;
        }*/

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

       /* public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,DateAdded,ImagePath")] Movie movie, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Générer un nom de fichier unique
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;

                    // Chemin complet pour enregistrer l'image localement
                    var filePath = Path.Combine("wwwroot/images", uniqueFileName);

                    // Enregistrez l'image localement
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }

                    // Mettez à jour le chemin d'accès dans le modèle
                    movie.ImagePath = "images/" + uniqueFileName;
                }

                _db.Add(movie);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }

        [HttpGet("ListMoviesByGenre/{genre}")]
        public IActionResult ListMoviesByGenre(string genre)
        {
            if (_db.Movies != null)
            {
                var moviesByGenre = _db.Movies
                .Where(m => m.Genre != null && m.Genre.GenreName != null && 
                    m.Genre.GenreName.ToUpper() == genre.ToUpper())
                .ToList();


                if (moviesByGenre.Any())
                {
                    return View(moviesByGenre);
                }
                else
                {
                    return NotFound($"No movie found for the genre {genre}");
                }
            }
            else
            {
                // Handle the case when Movies is null, e.g., log a warning or return an error response.
                return NotFound("Movies not available.");
            }
        }







        // GET: /<controller>/

        private List<Movie> movies = new List<Movie>()
        {
            new Movie{Name="Back to the Future I"},
            new Movie{Name="Back to the Future II"},
        };
        private static List<Customer> customers = new List<Customer>
        {
            new Customer { Name = "Chams Tmar" },
            new Customer { Name = "Neirez Cherni" },

        };

        public ActionResult? Edit(int id)
        {
            var film = _db.Movies?.Find(id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie film)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(film).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index"); // Rediriger vers la liste des films après l'édition
            }
            return View(film);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            var film = _db.Movies?.Find(id);

            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var film = _db.Movies?.Find(id);

            if (film == null)
            {
                return NotFound();
            }

            _db.Movies?.Remove(film);
            _db.SaveChanges();

            return RedirectToAction("Index"); // Rediriger vers la liste des films après la suppression
        }



        [Route("Movie/released/{year}/{month}")]
        public IActionResult ByRelease(int year, int month)
        {
            return Content($"Année : {year}, Mois : {month}");
        }

        [Route("Movies/CustomerDetails/{id}")]
        public IActionResult CustomerDetails(Guid? id)
        {
            // Recherchez le client par son ID dans la liste statique des clients.
            var customer = customers.FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound(); // Renvoie une réponse 404 si le client n'est pas trouvé.
            }

            return View(customer); // Passez le client trouvé à la vue.
        }*/
    }
}

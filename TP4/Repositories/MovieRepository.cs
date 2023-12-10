using TP4.Models;

namespace TP4.Repositories
{
    public class MovieRepository
    {
        public readonly ApplicationDbContext _db;
        public MovieRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        // Ecrire un service qui permet de lister tous les films associés à un genre défini par l’utilisateur avec une requête LINQ (dot notation syntax) permettant d’assurer l’extraction des données.
        public List<Movie> GetMoviesByUserDefinedGenre(int userDefinedGenre)
        {
            return _db.Movies.Where(movie => movie.GenreId == userDefinedGenre).ToList();
        }

        // Ecrire un service qui permet de lister tous les films ordonnés dans l’ordre croissant
        public List<Movie> GetAllMoviesOrderedByAscending()
        {
            return _db.Movies.OrderBy(movie => movie.Name).ToList();
            // You can change the sorting property according to your requirements (e.g., movie.Id, movie.ReleaseDate, etc.).
        }

        // Ecrire un service permettant de récupérer les films par leur genre ID
        public List<Movie> GetMoviesByGenreId(int genreId)
        {
            return _db.Movies.Where(movie => movie.GenreId == genreId).ToList();
        }
        public Movie GetMovieById(int id)
        {
            return _db.Movies.SingleOrDefault(x => x.Id == id);
        }
        public Movie GetMovieByName(string name)
        {
            return _db.Movies.SingleOrDefault(y => y.Name == name);
        }

        public List<Movie> GetAllMovies() {
            return (_db.Movies).ToList();
        }

        public List<Movie> GetMoviesByGenre(int genre)
        {
            return (_db.Movies.Where(item => item.GenreId == genre).ToList());
        }
        public void DeleteMovieById(int id)
        {
            Movie movie=this.GetMovieById(id);
            _db.Movies.Remove(movie);
            _db.SaveChanges();
        }

        public void AddMovie(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }
    }
}

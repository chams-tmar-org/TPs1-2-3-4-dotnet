using ASPCoreApplication2023.Models;
using ASPCoreApplication2023.Repositories;

namespace ASPCoreApplication2023.Services;

public class MovieService
{
    public readonly MovieRepository _repository;

    public MovieService(MovieRepository movieRepository)
    {
        this._repository = movieRepository;
    }

    public void CreateMovie(string name, Genre genre)
    {
        var movie = new Movie { Name = name, Genre = genre };
        _repository.AddMovie(movie);
    }


}
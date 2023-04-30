

using ViewModels;

namespace Services.Abstraction
{
    public interface IMovieService
    {
        List<MovieViewModel> GetMovies();
        MovieViewModel GetMovie(int id);
        List<MovieViewModel> RandomMovies();
        void AddMovie(MovieViewModel movie);
        void UpdateMovie(MovieViewModel movie);
        void DeleteMovie(MovieViewModel movie);
    }
}

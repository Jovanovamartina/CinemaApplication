using AutoMapper;
using CinemaAppMVC.Repositories.Abstraction;
using DomainModels;
using Services.Abstraction;
using ViewModels;

namespace Services.Implementation
{
    public class MovieService : IMovieService
    {
        //Repository
        //Mapper
        private readonly IRepository<Movie> _movieRepository;
        private readonly IMapper _mapper;
        public MovieService(IRepository<Movie> movieRepository,IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        //Add
        public void AddMovie(MovieViewModel movie)
        {
            _movieRepository.Add(_mapper.Map<Movie>(movie));
        }

        //Delete
        public void DeleteMovie(MovieViewModel movie)
        {
            _movieRepository.Delete(_movieRepository.GetById(movie.Id));
        }

        //Get All
        public List<MovieViewModel> GetMovies()
        {
            return _movieRepository.GetAll().Select(x => _mapper.Map<MovieViewModel>(x)).ToList();
        }

        //Get By Id
        public MovieViewModel GetMovie(int id)
        {
            return _mapper.Map<MovieViewModel>(_movieRepository.GetById(id));
        }

        //random Movies
        public List<MovieViewModel> RandomMovies()
        {
            Random random = new Random();
            List<MovieViewModel> movieModels = GetMovies();
            List<MovieViewModel> moviesModelsToSend = new List<MovieViewModel>();
            for (int i = 0; i < 4; i++)
            {
                int rnd = random.Next(1, movieModels.Count);
                MovieViewModel movie = movieModels[rnd];

                if (moviesModelsToSend.Contains(movie))
                {
                    moviesModelsToSend.Remove(movie);
                }
                else
                {
                    moviesModelsToSend.Add(movie);
                }
            }
            return moviesModelsToSend;
        }

        //Update
        public void UpdateMovie(MovieViewModel movie)
        {
            Movie movieObject = _movieRepository.GetById(movie.Id);
            movieObject.Id = movie.Id;
            movieObject.Duration = movie.Duration;
            movieObject.Description = movie.Description;
            movieObject.Genre = movie.Genre;
            movieObject.Image = movie.Image;
            movieObject.Title = movie.Title;
            movieObject.YearReleased = movie.YearReleased;
            _movieRepository.Update(movieObject);
        }
    }
}



using AutoMapper;
using CinemaAppMVC.Repositories.Abstraction;
using DomainModels;
using Services.Abstraction;
using ViewModels;

namespace Services.Implementation
{
    public class MovieProgramService : IMovieProgramService
    {
        //repository,mapper
        private readonly IRepository<MovieProgram> _movieProgramRepository;
        private readonly IMapper _mapper;
        public MovieProgramService(IRepository<MovieProgram> movieProgramRepository,IMapper mapper)
        {
            _movieProgramRepository = movieProgramRepository;
            _mapper = mapper;
        }
        //Add movie PRogram
        public void AddMovieProgram(MovieProgramViewModel movieProgram)
        {
            _movieProgramRepository.Add(_mapper.Map<MovieProgram>(movieProgram));
        }

        //Delete movie program
        public void DeleteMovieProgram(MovieProgramViewModel movieProgram)
        {
            _movieProgramRepository.Delete(_movieProgramRepository.GetById(movieProgram.Id));
        }
        // Get Movie PRogram
        public MovieProgramViewModel GetMovieProgram(int id)
        {
            return _mapper.Map<MovieProgramViewModel>(_movieProgramRepository.GetById(id));
        }

        //Get Movie Programs
        public List<MovieProgramViewModel> GetMoviePrograms()
        {
            return _movieProgramRepository.GetAll().Select(x => _mapper.Map<MovieProgramViewModel>(x)).ToList();
        }

        public void UpdateMovieProgram(MovieProgramViewModel movieProgram)
        {
            MovieProgram movieProgramObject = _movieProgramRepository.GetById(movieProgram.Id);
            movieProgramObject.Id = movieProgram.Id;
            movieProgramObject.CinemaHallId = movieProgram.CinemaHallId;
            movieProgramObject.Date = movieProgram.Date;
            movieProgramObject.EndTime = movieProgram.EndTime;
            movieProgramObject.Price = movieProgram.Price;
            movieProgramObject.StartTime = movieProgram.StartTime;
            _movieProgramRepository.Update(movieProgramObject);
        }
    }
}

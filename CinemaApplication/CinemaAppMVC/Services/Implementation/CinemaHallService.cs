

using AutoMapper;
using CinemaAppMVC.Repositories.Abstraction;
using DomainModels;
using Services.Abstraction;
using ViewModels;

namespace Services.Implementation
{
    public class CinemaHallService : ICinemaHallService
    {
        //Repository,mapper
        private readonly IRepository<CinemaHall> _cinemaHallRepository;
        private readonly IMapper _mapper;
        public CinemaHallService(IRepository<CinemaHall> cinemaHallRepository,IMapper mapper)
        {
            _cinemaHallRepository = cinemaHallRepository;
            _mapper = mapper;
        }

        //Add cinemaHall
        public int AddCinemaHall(CinemaHallViewModel cinemaHall)
        {
            CinemaHall cinemaHallObject = new CinemaHall()
            {
                MovieId = cinemaHall.MovieId,
                SizeId = cinemaHall.SizeId
            };
            _cinemaHallRepository.Add(cinemaHallObject);
            return cinemaHallObject.Id;
        }

        //Get All
        public CinemaHallViewModel GetCinemaHall(int id)
        {
            return _mapper.Map<CinemaHallViewModel>(_cinemaHallRepository.GetById(id));
        }

        //Get Cinema Hall
        public List<CinemaHallViewModel> GetCinemaHalls()
        {
            return _cinemaHallRepository.GetAll().Select(x => _mapper.Map<CinemaHallViewModel>(x)).ToList();
        }

        //update cinema hall
        public void UpdateCinemaHall(CinemaHallViewModel cinemaHall)
        {
            CinemaHall cinemaHallObj = _cinemaHallRepository.GetById(cinemaHall.Id);
            cinemaHallObj.Id = cinemaHall.Id;
            cinemaHallObj.MovieId = cinemaHall.MovieId;
            cinemaHallObj.SizeId = cinemaHall.SizeId;
            _cinemaHallRepository.Update(cinemaHallObj);
        }
    }
}

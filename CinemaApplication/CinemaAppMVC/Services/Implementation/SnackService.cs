using AutoMapper;
using CinemaAppMVC.Repositories.Abstraction;
using CinemaAppMVC.Services.Abstraction;
using DomainModels;
using ViewModels;

namespace CinemaAppMVC.Services.Implementation
{
    public class SnackService : ISnackService
    {
        //Repository
        //Mapper
        private IRepository<Snack> _snackRepository;
        private readonly IMapper _mapper;
        public SnackService(IRepository<Snack> snackRepository,IMapper mapper)
        {
            _snackRepository = snackRepository;
            _mapper = mapper;
        }

        //Add
        public void AddSnack(SnackViewModel snack)
        {
            _snackRepository.Add(_mapper.Map<Snack>(snack));
        }

        //Delete
        public void DeleteSnack(SnackViewModel snack)
        {
            _snackRepository.Delete(_snackRepository.GetById(snack.Id));
        }

        //Get by Id
        public SnackViewModel GetSnack(int id)
        {
           return _mapper.Map<SnackViewModel>(_snackRepository.GetById(id));
        }

        //Get All
        public List<SnackViewModel> GetSnacks()
        {
            return _snackRepository.GetAll().Select(x => _mapper.Map<SnackViewModel>(x)).ToList();
        }

        //Update

        public void UpdateSnack(SnackViewModel snack)
        {
            Snack snackObject = _snackRepository.GetById(snack.Id);
            snackObject.Id = snack.Id;
            snackObject.Image = snack.Image;
            snackObject.Name = snack.Name;
            snackObject.Price = snack.Price;
            _snackRepository.Update(snackObject);
        }
    }
}


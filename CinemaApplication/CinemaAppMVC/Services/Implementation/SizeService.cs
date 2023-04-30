using AutoMapper;
using CinemaAppMVC.Repositories.Abstraction;
using DomainModels;
using Services.Abstraction;
using ViewModels;

namespace Services.Implementation
{
    public class SizeService : ISizeService
    {
        //Repository
        //Mapper
        private readonly IRepository<Size> _sizeRepository;
        private readonly IMapper _mapper;
        public SizeService(IRepository<Size> sizeRepository,IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        //Get All
        public List<SizeViewModel> GetSizes()
        {
           return _sizeRepository.GetAll().Select(x => _mapper.Map<SizeViewModel>(x)).ToList();
        }
    }
}

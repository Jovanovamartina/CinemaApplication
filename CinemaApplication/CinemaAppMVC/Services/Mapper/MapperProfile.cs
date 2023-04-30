using AutoMapper;
using DomainModels;
using ViewModels;

namespace Services.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Snack, SnackViewModel>().ReverseMap();
            CreateMap<Size, SizeViewModel>().ReverseMap();
            CreateMap<Movie, MovieViewModel>().ReverseMap();
            CreateMap<CinemaHall, CinemaHallViewModel>().ReverseMap();
            CreateMap<MovieProgram, MovieProgramViewModel>().ReverseMap();
            CreateMap<Reservation, ReservationViewModel>().ReverseMap();
            CreateMap<SnackOrder, SnackOrderViewModel>().ReverseMap();
        }
    }
}



using ViewModels;

namespace Services.Abstraction
{
    public interface ICinemaHallService
    {
        List<CinemaHallViewModel> GetCinemaHalls();
        CinemaHallViewModel GetCinemaHall(int id);
        int AddCinemaHall(CinemaHallViewModel cinemaHall);
        void UpdateCinemaHall(CinemaHallViewModel cinemaHall);
    }
}

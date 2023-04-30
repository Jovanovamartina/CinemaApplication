
using ViewModels;

namespace Services.Abstraction
{
    public interface IReservationService
    {
        ReservationViewModel GetReservation(int id);
        List<ReservationViewModel> GetReservations();
        void AddReservation(ReservationViewModel model);
        void DeleteReservation(ReservationViewModel model);
    }
}

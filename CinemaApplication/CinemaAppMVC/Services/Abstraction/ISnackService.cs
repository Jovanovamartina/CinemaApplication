
using ViewModels;

namespace CinemaAppMVC.Services.Abstraction
{
    public interface ISnackService
    {
        List<SnackViewModel> GetSnacks();
        SnackViewModel GetSnack(int id);
        void UpdateSnack(SnackViewModel snack);
        void AddSnack(SnackViewModel snack);
        void DeleteSnack(SnackViewModel snack);
    }
}

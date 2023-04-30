using CinemaAppMVC.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using ViewModels;

namespace CinemaApp.Controllers
{
    public class ReservationController : Controller
    {
        //services
        private readonly IReservationService _reservationService;
        private readonly ISnackService _snackService;

        public ReservationController(IReservationService reservationService, ISnackService snackService)
        {
            _reservationService = reservationService;
            _snackService = snackService;
        }
        //index
        public IActionResult Index()
        {
            return View(_reservationService.GetReservations());
        }
        //Get movie program
        public IActionResult GetMovieProgram(int id)
        {
            return RedirectToAction("MakeAReservation", new ReservationViewModel() { MovieProgramId = id });
        }
        //make and save reservation
        public IActionResult MakeAReservation(ReservationViewModel model)
        {
            List<SnackViewModel> snacks = _snackService.GetSnacks();
            ViewBag.Snacks = snacks;
            model.SnackOrders = null;
            return View(model);
        }
        [HttpPost]
        public IActionResult SaveReservation(ReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                _reservationService.AddReservation(model);
                return RedirectToAction("Index");
            }
            return RedirectToAction("MakeAReservation", model);
        }
        //Details
        public IActionResult Details(int id)
        {
            return View(_reservationService.GetReservation(id));
        }
        //Delete
        public IActionResult DeleteReservation(int id)
        {
            _reservationService.DeleteReservation(_reservationService.GetReservation(id));
            return RedirectToAction("Index");
        }
        //Search reservation
        public IActionResult SearchReservation(string id)
        {
            if (int.TryParse(id, out int resId))
            {
                if (_reservationService.GetReservations().Any(x => x.Id == resId))
                {
                    return View(_reservationService.GetReservation(resId));
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}

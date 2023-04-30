using CinemaAppMVC.Services.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace CinemaApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SnackController : Controller
    {
      //services
        private readonly ISnackService _snackService;
        public SnackController(ISnackService snackService)
        {
            _snackService = snackService;
        }

        //Get All
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_snackService.GetSnacks());
        }

        //Add Or Update
        public IActionResult AddNewSnack(int id)
        {
            if (id != 0)
            {
                SnackViewModel snackViewModel = _snackService.GetSnack(id);
                return View(snackViewModel);
            }
            return View(new SnackViewModel());
        }

        [HttpPost]
        public IActionResult AddNewSnack(SnackViewModel model)
        {
            if (model.Name != null && model.Image != null)
            {
                if (model.Id != 0)
                {
                    _snackService.UpdateSnack(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    _snackService.AddSnack(model);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(model);
            }
        }

       
        //Delete
        public IActionResult DeleteSnack(int id)
        {
            _snackService.DeleteSnack(_snackService.GetSnack(id));
            return RedirectToAction("Index");
        }


        //Search Snack
       [AllowAnonymous]
        public IActionResult SearchSnacks(string id)
        {
            if (string.IsNullOrEmpty(id) || !_snackService.GetSnacks().Any(x => x.Name.ToLower().Contains(id.ToLower())))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(_snackService.GetSnacks().Where(x => x.Name.ToLower().Contains(id.ToLower())).ToList());
            }
        }
    }
}

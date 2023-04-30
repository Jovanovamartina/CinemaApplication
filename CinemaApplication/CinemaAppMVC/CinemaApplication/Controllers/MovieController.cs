using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using ViewModels;

namespace CinemaApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class MovieController : Controller
    {
        //services
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //Get All
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_movieService.GetMovies());
        }

        //Add or Update
        public IActionResult AddOrUpdateMovie(int id)
        {
            if (id != 0)
            {
                MovieViewModel movieViewModel = _movieService.GetMovie(id);
                return View(movieViewModel);
            }
            else
            {
                return View(new MovieViewModel());
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdateMovie(MovieViewModel movie)
        {
            if (ModelState.IsValid)
            {
                if(movie.Id != 0)
                {
                    _movieService.UpdateMovie(movie);
                    return RedirectToAction("Index");
                }
                else
                {
                    _movieService.AddMovie(movie);
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(movie);
            }
        }
        //Delete movie
        public IActionResult DeleteMovie(int id)
        {
            _movieService.DeleteMovie(_movieService.GetMovie(id));
            return RedirectToAction("Index");
        }

        //Search Movies
        public IActionResult SearchMovie(string id)
        {
            if (string.IsNullOrEmpty(id) || !_movieService.GetMovies().Any(x => x.Title.ToLower().Contains(id.ToLower())))
            {
                return RedirectToAction("Index");
            }
            else
            {
               return View(_movieService.GetMovies().Where(x => x.Title.ToLower().Contains(id.ToLower())).ToList());
            }
        }

        //Filter Movies
        public IActionResult FilterMovies(string id)
        {
            return View(_movieService.GetMovies().Where(x => x.Genre.ToLower().Contains(id.ToLower())).ToList());
        }

    }
}

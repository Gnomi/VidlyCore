using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VidlyCore.Models;

namespace VidlyCore.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            var movies = GetMovies();


            return View(movies);
        }


        private IEnumerable<Movie> GetMovies()
        {
             return new List<Movie>
             {
                 new Movie { Id = 1, Name = "Shrek" },
                 new Movie { Id = 2, Name = "Wall-e" }
             };
        }


        [Route("movies/released/{year}/{month:regex(^\\d{{2}}$)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }


        // GET: Movies/Random
        public ActionResult Random()
        {

            var movie = new Movie { Name = "Sherk Reunion!" };


            return View(movie);
        }
    }
}
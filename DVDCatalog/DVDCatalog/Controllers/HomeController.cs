using DVDCatalog.DAOs;
using DVDCatalog.Models;
using DVDCatalog.Workers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DVDCatalog.Controllers
{
    public class HomeController : Controller
    {
        Movie movie;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            movie = new Movie();
        }

        [HttpGet]
        public IActionResult Index()
        {
            CatalogModel model = new CatalogModel(movie.GetAllMovies());
        
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string title)
        {
            MovieDAO searchedMovie = movie.MovieSearch(title);
            
            CatalogModel model = new CatalogModel();
            
            model.Catalog.Add(searchedMovie);
            
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNewMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(MovieModel movieModel)
        {
            MovieDAO movieDAO = new MovieDAO(movieModel);
            bool addNewMovieSuccess = movie.AddNewMovie(movieDAO);
            
            if(addNewMovieSuccess)
            {
                return View("Index", new CatalogModel(movie.GetAllMovies()));
            }
            
            return View("Error");
        }

        [HttpPost]
        public IActionResult DeleteMovie(string title)
        {
            bool deleteMovieSuccess = movie.DeleteMovie(title);
            if(deleteMovieSuccess)
            {
                return View("Index", new CatalogModel(movie.GetAllMovies()));
            }
            return View("Error");
        }

        [HttpPost]
        public IActionResult EditMovie(string title)
        {
            MovieDAO searchedMovie = movie.MovieSearch(title);
            MovieModel model = new MovieModel(searchedMovie);

            return View(model);
        }

        [HttpPost]
        public IActionResult SubmitEditMovie(MovieModel movieModel)
        {
            bool successfulEdit = movie.EditMovie(new MovieDAO(movieModel));

            if(successfulEdit)
            {
                return View("Index", new CatalogModel(movie.GetAllMovies()));
            }
            return View("Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
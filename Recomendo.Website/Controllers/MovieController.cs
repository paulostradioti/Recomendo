using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Recomendo.Website.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Recomendo.Website.Controllers
{
    public class MovieController : Controller
    {
        private readonly IRepository repository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public MovieController(IRepository repository, IWebHostEnvironment webHostEnvironment)
        {
            this.repository = repository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(repository.Movies);
        }

        public IActionResult Details(int id)
        {
            var movie = repository.Movies.FirstOrDefault(x => x.Id == id);
            return View(movie);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = repository.Movies.FirstOrDefault(x => x.Id == id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var movie = repository.Movies.FirstOrDefault(x => x.Id == id);
            repository.Delete(movie);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            var imagePath = @"\images\movies\";
            var hasAttachment = HttpContext.Request.Form.Files.Count > 0;

            if (!hasAttachment)
                ModelState.AddModelError(nameof(Movie.Image), "A Capa ou Poster do Filme é Obrigatório");

            if (ModelState.IsValid)
            {
                if (hasAttachment)
                {
                    var files = HttpContext.Request.Form.Files;
                    string webRootPath = webHostEnvironment.WebRootPath;
                    string upload = webRootPath + imagePath;
                    string fileName = Guid.NewGuid().ToString();
                    string extension = Path.GetExtension(files[0].FileName);

                    using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    movie.Image = fileName + extension;
                }


                repository.Add(movie);
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        public IActionResult Edit(int id)
        {
            var movie = repository.Movies.FirstOrDefault(x => x.Id == id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            var imagePath = @"\images\movies\";
            var hasAttachment = HttpContext.Request.Form.Files.Count > 0;

            if (hasAttachment)
            {
                var files = HttpContext.Request.Form.Files;
                string webRootPath = webHostEnvironment.WebRootPath;
                string upload = webRootPath + imagePath;
                string fileName = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(upload, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                movie.Image = fileName + extension;
            }

            repository.Update(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}

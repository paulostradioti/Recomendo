using Microsoft.AspNetCore.Mvc;
using Recomendo.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recomendo.Website.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository repository;

        public CategoryController(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(repository.Categories);
        }

        public IActionResult Edit(int id)
        {
            var category = repository.Categories.FirstOrDefault(x => x.Id == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                repository.Update(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                repository.Add(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = repository.Categories.FirstOrDefault(x => x.Id == id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            repository.Delete(category);
            return RedirectToAction(nameof(Index));
        }
    }
}

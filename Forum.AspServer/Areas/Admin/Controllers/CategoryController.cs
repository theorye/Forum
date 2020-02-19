using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Forum.AspServer.Services.Interfaces;
using Forum.Domain;
using Microsoft.AspNetCore.Mvc;

namespace SimpleForum.AspServer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        // GET
        public IActionResult Index()
        {

            List<Category> model = _service.GetAll();

            return View(model);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(string id)
        {
            Category model = _service.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public IActionResult Edit(string id)
        {
            Category model = _service.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        public IActionResult Delete(string id)
        {
            Category model = _service.GetById(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // Actions

        // POST - CREATE
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Create(Category category)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            new CategoryDataContext(dbAccess).Create(category.Title);

    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(category);
    //    }

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult Edit(Category category)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            new CategoryDataContext(dbAccess).Update(category);


    //            return RedirectToAction(nameof(Index));
    //        }

    //        return View(category);
    //    }

    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public IActionResult DeleteConfirmed(int id)
    //    {
    //        new CategoryDataContext(dbAccess).Delete(id);


    //        return RedirectToAction(nameof(Index));
    //    }

    }
}
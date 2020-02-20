using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.AspServer.Models;
using Forum.AspServer.Services.Interfaces;
using Forum.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Forum.AspServer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ForumController : Controller
    {
        private readonly IForumService _forumService;
        private readonly ICategoryService _categoryService;

        [BindProperty]
        public AdminForumViewModel AdminForumVM { get; set; }

        public ForumController( IForumService forumService, ICategoryService categoryService)
        {
            _forumService = forumService;
            _categoryService = categoryService;

            AdminForumVM = new AdminForumViewModel
            {
                Forum = new ForumModel(),
                Categories = _categoryService.GetAll()
            };

        }

        public IActionResult Index()
        {

            List<ForumModel> model = _forumService.GetAll();

            return View(model);
        }

        public IActionResult Create()
        {
            return View(AdminForumVM);
        }

        public IActionResult Details(int id)
        {

            AdminForumVM.Forum = _forumService.GetById(id);

            if (AdminForumVM.Forum == null)
            {
                return NotFound();
            }
            
            return View(AdminForumVM);
        }

        public IActionResult Edit(int id)
        {
            AdminForumVM.Forum = _forumService.GetById(id);

            if (AdminForumVM.Forum == null)
            {
                return NotFound();
            }

            return View(AdminForumVM);
        }

        public IActionResult Delete(int id)
        {
            AdminForumVM.Forum = _forumService.GetById(id);

            if (AdminForumVM.Forum == null)
            {
                return NotFound();
            }

            return View(AdminForumVM.Forum);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ForumModel forum)
        {
            if (!ModelState.IsValid)
            {
                return View(forum);

            }
            IFormFileCollection files = HttpContext.Request.Form.Files;

            _forumService.Create(forum, files);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ForumModel forum)
        {
            if (ModelState.IsValid)
            {
                _forumService.Update(forum);

                return RedirectToAction(nameof(Index));
            }

            return View(forum);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _forumService.Delete(id);


            return RedirectToAction(nameof(Index));
        }
    }
}
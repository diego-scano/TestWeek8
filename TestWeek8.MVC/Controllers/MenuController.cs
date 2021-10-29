using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeek8.Core.Interfaces;
using TestWeek8.Core.Models;
using TestWeek8.MVC.Helpers;
using TestWeek8.MVC.Models;

namespace TestWeek8.MVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMainBusinessLayer mainBL;
        public MenuController(IMainBusinessLayer mainBL)
        {
            this.mainBL = mainBL;
        }

        public IActionResult Index()
        {
            var result = mainBL.FetchMenus();
            var resultMap = result.ToListMenuViewModel();
            return View(resultMap);
        }

        public IActionResult Details(int id)
        {
            var result = mainBL.FetchPiatti().Where(p => p.MenuId == id);
            var resultMap = result.ToListPiattoViewModel();
            return View(resultMap);
        }

        [Authorize(Policy = "AdministratorUser")]
        public IActionResult Create()
        {
            return View(new MenuViewModel());
        }

        [HttpPost]
        public IActionResult Create(MenuViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (model == null)
                return View("Error");
            Menu newMenu = model.ToMenu();
            var result = mainBL.CreateMenu(newMenu);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "AdministratorUser")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return View("Error");
            var result = mainBL.DeleteMenuById(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

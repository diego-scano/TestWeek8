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
    public class PiattiController : Controller
    {
        private readonly IMainBusinessLayer mainBL;
        public PiattiController(IMainBusinessLayer mainBL)
        {
            this.mainBL = mainBL;
        }

        [Authorize(Policy = "AdministratorUser")]
        public IActionResult Create()
        {
            LoadViewBag();
            return View(new PiattoViewModel());
        }

        [HttpPost]
        public IActionResult Create(PiattoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (model == null)
                return View("Error");
            Piatto newPiatto = model.ToPiatto();
            var result = mainBL.CreatePiatto(newPiatto);
            return RedirectToAction("/");
        }

        [Authorize(Policy = "AdministratorUser")]
        public IActionResult Edit(int id)
        {
            if (id <= 0)
                return View("Error");
            var piattoToEdit = mainBL.GetPiattoById(id);
            if (piattoToEdit == null)
                return View("Error");
            var piattoViewModel = piattoToEdit.ToPiattoViewModel();
            LoadViewBag();
            return View(piattoViewModel);
        }

        [HttpPost]
        public IActionResult Edit(PiattoViewModel evm)
        {
            if (!ModelState.IsValid)
            {
                return View(evm);
            }
            if (evm == null)
                return View("Error");
           
            var piattoToEdit = evm.ToPiatto();
            mainBL.EditPiatto(piattoToEdit);
          
            return RedirectToAction("Details");
        }

        [Authorize(Policy = "AdministratorUser")]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return View("Error");
            
            var result = mainBL.DeletePiattoById(id);
            return View("Details");
        }

        private void LoadViewBag()
        {
            ViewBag.Categories = new SelectList(new[]
            {
                "Primo", "Secondo", "Contorno", "Dolce"
            });

            var menuList = mainBL.FetchMenus();
            ViewBag.Menus = menuList.FromListToSelectList();
        }
    }
}

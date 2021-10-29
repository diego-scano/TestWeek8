using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeek8.Core.Models;
using TestWeek8.MVC.Models;

namespace TestWeek8.MVC.Helpers
{
    public static class MappingExtensions
    {
        public static MenuViewModel ToMenuViewModel(this Menu menu)
        {
            return new MenuViewModel
            {
                Id = menu.Id,
                Nome = menu.Nome
            };
        }

        public static IEnumerable<MenuViewModel> ToListMenuViewModel(this IEnumerable<Menu> menu)
        {
            return menu.Select(e => e.ToMenuViewModel());
        }

        public static Menu ToMenu(this MenuViewModel menuViewModel)
        {
            return new Menu
            {
                Id = menuViewModel.Id,
                Nome = menuViewModel.Nome,
                Piatti = (IEnumerable<Piatto>)menuViewModel.Piatti
            };
        }

        public static IEnumerable<SelectListItem> FromListToSelectList(this IEnumerable<Menu> menuList)
        {
            return menuList.Select(
                    e => new SelectListItem()
                    {
                        Text = e.Nome,
                        Value = e.Nome
                    }).ToList();
        }

        public static PiattoViewModel ToPiattoViewModel(this Piatto piatto)
        {
            return new PiattoViewModel
            {
                Id = piatto.Id,
                Nome = piatto.Nome,
                Tipo = piatto.Tipo,
                Prezzo = piatto.Prezzo,
                MenuId = piatto.MenuId,
                Menu = piatto.Menu
            };
        }

        public static IEnumerable<PiattoViewModel> ToListPiattoViewModel(this IEnumerable<Piatto> piatto)
        {
            return piatto.Select(e => e.ToPiattoViewModel());
        }

        public static Piatto ToPiatto(this PiattoViewModel piattoViewModel)
        {
            return new Piatto
            {
                Id = piattoViewModel.Id,
                Nome = piattoViewModel.Nome,
                Tipo = piattoViewModel.Tipo,
                Prezzo = piattoViewModel.Prezzo,
                MenuId = piattoViewModel.MenuId,
                Menu = piattoViewModel.Menu
            };
        }
    }
}

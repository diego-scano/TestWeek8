using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek8.Core.Interfaces;
using TestWeek8.Core.Models;

namespace TestWeek8.Core
{
    public class MainBusinessLayer : IMainBusinessLayer
    {
        private readonly IMenuRepository menuRepo;
        private readonly IPiattoRepository piattoRepo;
        private readonly IUtenteRepository utenteRepo;

        public MainBusinessLayer(IMenuRepository menuRepo, IPiattoRepository piattoRepo, IUtenteRepository utenteRepo)
        {
            this.menuRepo = menuRepo;
            this.piattoRepo = piattoRepo;
            this.utenteRepo = utenteRepo;
        }

        #region Menu
        public IEnumerable<Menu> FetchMenus(Func<Menu, bool> filter = null)
        {
            return menuRepo.Fetch(filter);
        }

        public Menu GetMenuById(int id)
        {
            if (id <= 0)
                return null;
            return menuRepo.GetById(id);
        }

        public bool CreateMenu(Menu newMenu)
        {
            if (newMenu == null)
                return false;
            menuRepo.AddItem(newMenu);
            return true;
        }

        public bool EditMenu(Menu modifiedMenu)
        {
            if (modifiedMenu == null)
                return false;
            menuRepo.UpdateItem(modifiedMenu);
            return true;
        }

        public bool DeleteMenuById(int id)
        {
            if (id <= 0)
                return false;
            menuRepo.DeleteItemById(id);
            return true;
        }
        #endregion

        #region Piatto
        public IEnumerable<Piatto> FetchPiatti(Func<Piatto, bool> filter = null)
        {
            return piattoRepo.Fetch(filter);
        }

        public Piatto GetPiattoById(int id)
        {
            if (id <= 0)
                return null;
            return piattoRepo.GetById(id);
        }

        public bool CreatePiatto(Piatto newPiatto)
        {
            if (newPiatto == null)
                return false;
            piattoRepo.AddItem(newPiatto);
            return true;
        }

        public bool EditPiatto(Piatto modifiedPiatto)
        {
            if (modifiedPiatto == null)
                return false;
            piattoRepo.UpdateItem(modifiedPiatto);
            return true;
        }

        public bool DeletePiattoById(int id)
        {
            if (id <= 0)
                return false;
            piattoRepo.DeleteItemById(id);
            return true;
        }

        public Utente GetUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;
            return utenteRepo.GetByEmail(email);
        }
        #endregion
    }
}

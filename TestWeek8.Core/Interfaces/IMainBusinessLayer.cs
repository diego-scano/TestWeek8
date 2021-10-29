using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek8.Core.Models;

namespace TestWeek8.Core.Interfaces
{
    public interface IMainBusinessLayer
    {
        #region Menu
        IEnumerable<Menu> FetchMenus(Func<Menu, bool> filter = null);
        Menu GetMenuById(int id);
        bool CreateMenu(Menu newMenu);
        bool EditMenu(Menu modifiedMenu);
        bool DeleteMenuById(int id);
        #endregion

        #region Piatto
        IEnumerable<Piatto> FetchPiatti(Func<Piatto, bool> filter = null);
        Piatto GetPiattoById(int id);
        bool CreatePiatto(Piatto newPiatto);
        bool EditPiatto(Piatto modifiedPiatto);
        bool DeletePiattoById(int id);
        #endregion

        Utente GetUserByEmail(string email);
    }
}

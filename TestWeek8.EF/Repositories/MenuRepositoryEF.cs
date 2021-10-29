using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek8.Core.Interfaces;
using TestWeek8.Core.Models;

namespace TestWeek8.EF.Repositories
{
    public class MenuRepositoryEF : IMenuRepository
    {
        private readonly MainContext ctx;
        public MenuRepositoryEF(MainContext ctx)
        {
            this.ctx = ctx;
        }

        public bool AddItem(Menu item)
        {
            if (item == null)
                return false;
            ctx.Menus.Add(item);
            ctx.SaveChanges();
            return true;
        }

        public bool DeleteItemById(int id)
        {
            if (id <= 0)
                return false;
            var menuToDelete = GetById(id);
            if (menuToDelete == null)
                return false;
            ctx.Menus.Remove(menuToDelete);
            ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Menu> Fetch(Func<Menu, bool> filter = null)
        {
            if (filter != null)
                return ctx.Menus.Where(filter);
            return ctx.Menus;
        }

        public Menu GetById(int id)
        {
            if (id <= 0)
                return null;
            return ctx.Menus.Find(id);
        }

        public bool UpdateItem(Menu updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}

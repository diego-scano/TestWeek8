using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek8.Core.Interfaces;
using TestWeek8.Core.Models;

namespace TestWeek8.EF.Repositories
{
    public class PiattoRepositoryEF : IPiattoRepository
    {
        private readonly MainContext ctx;
        public PiattoRepositoryEF(MainContext ctx)
        {
            this.ctx = ctx;
        }
        public bool AddItem(Piatto item)
        {
            if (item == null)
                return false;
            ctx.Piatti.Add(item);
            ctx.SaveChanges();
            return true;
        }

        public bool DeleteItemById(int id)
        {
            if (id <= 0)
                return false;
            var piattoToDelete = GetById(id);
            if (piattoToDelete == null)
                return false;
            ctx.Piatti.Remove(piattoToDelete);
            ctx.SaveChanges();
            return true;
        }

        public IEnumerable<Piatto> Fetch(Func<Piatto, bool> filter = null)
        {
            if (filter != null)
                return ctx.Piatti.Where(filter);
            return ctx.Piatti;
        }

        public Piatto GetById(int id)
        {
            if (id <= 0)
                return null;
            return ctx.Piatti.Find(id);
        }

        public bool UpdateItem(Piatto updatedItem)
        {
            if (updatedItem == null)
                return false;
            ctx.Entry(updatedItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ctx.SaveChanges();
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeek8.Core.Interfaces;
using TestWeek8.Core.Models;

namespace TestWeek8.EF.Repositories
{
    public class UtenteRepositoryEF : IUtenteRepository
    {
        private readonly MainContext ctx;

        public UtenteRepositoryEF(MainContext ctx)
        {
            this.ctx = ctx;
        }

        public bool AddItem(Utente item)
        {
            throw new NotImplementedException();
        }

        public bool DeleteItemById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Utente> Fetch(Func<Utente, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public Utente GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;
            return ctx.Utenti.FirstOrDefault(u => u.Email.Equals(email));
        }

        public Utente GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(Utente updatedItem)
        {
            throw new NotImplementedException();
        }
    }
}

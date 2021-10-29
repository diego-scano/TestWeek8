using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeek8.Core.Models;

namespace TestWeek8.MVC.Models
{
    public class PiattoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Tipologia Tipo { get; set; }
        public decimal Prezzo { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}

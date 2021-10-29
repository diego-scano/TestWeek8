using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek8.Core.Models
{
    public enum Tipologia { Primo, Secondo, Contorno, Dolce}
    public class Piatto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Tipologia Tipo { get; set; }
        public decimal Prezzo { get; set; }
        public int MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}

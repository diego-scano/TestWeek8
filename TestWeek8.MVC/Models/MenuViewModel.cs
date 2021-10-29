using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestWeek8.Core.Models;

namespace TestWeek8.MVC.Models
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Inserisci nome")]
        public string Nome { get; set; }
        public IEnumerable<PiattoViewModel> Piatti { get; set; }
    }
}

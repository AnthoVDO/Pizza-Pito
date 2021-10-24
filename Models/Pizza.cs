using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Pito.Models
{
    public class Pizza
    {
        public int PizzaID { get; set; }
        public string nom { get; set; }
        public float prix { get; set; }
        public bool vegetarienne { get; set; }
        public string ingredients { get; set; }
    }
}

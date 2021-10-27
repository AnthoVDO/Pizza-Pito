using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza_Pito.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pizza_Pito.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : Controller
    {


        private readonly Pizza_Pito.Data.DataContext _context;
        public ApiController(Pizza_Pito.Data.DataContext context)
        {
            _context = context;
        }
        public IList<Pizza> Pizza { get; set; }
        //public async Task OnGetAsync()
        //{
        //    Pizza = await _context.Pizzas.ToListAsync();
        //}


        // GET: api/<ApiController>
        [HttpGet]
        [Route("GetPizza")]
        public IActionResult GetPizza()
        {
            //var pizza = new Pizza() {nom="pizza test", prix=8, vegetarienne=false, ingredients="tomate, oignons, oeuf, jambon" };

            //1-DataContext
            //2-Récupérer les pizzas -> Json
            Pizza = _context.Pizzas.ToList();
            return Json(Pizza);
        }

    }
}

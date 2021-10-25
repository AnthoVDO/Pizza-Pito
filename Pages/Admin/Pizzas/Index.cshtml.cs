using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pizza_Pito.Data;
using Pizza_Pito.Models;

namespace Pizza_Pito.Pages.Admin.Pizzas
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Pizza_Pito.Data.DataContext _context;

        public IndexModel(Pizza_Pito.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Pizza> Pizza { get;set; }

        public async Task OnGetAsync()
        {
            Pizza = await _context.Pizzas.ToListAsync();
        }
    }
}

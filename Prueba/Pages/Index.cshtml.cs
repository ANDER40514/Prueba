using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Prueba.Data;
using Prueba.Models;

namespace Prueba.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Prueba.Data.PruebaContext _context;

        public IndexModel(Prueba.Data.PruebaContext context)
        {
            _context = context;
        }

        public IList<Persona> Persona { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Persona != null)
            {
                Persona = await _context.Persona.ToListAsync();
            }
        }
    }
}

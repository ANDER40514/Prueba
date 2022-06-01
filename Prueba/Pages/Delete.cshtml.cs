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
    public class DeleteModel : PageModel
    {
        private readonly Prueba.Data.PruebaContext _context;

        public DeleteModel(Prueba.Data.PruebaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Persona Persona { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona.FirstOrDefaultAsync(m => m.ID == id);

            if (persona == null)
            {
                return NotFound();
            }
            else 
            {
                Persona = persona;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }
            var persona = await _context.Persona.FindAsync(id);

            if (persona != null)
            {
                Persona = persona;
                _context.Persona.Remove(Persona);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

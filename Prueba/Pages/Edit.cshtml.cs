using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prueba.Data;
using Prueba.Models;

namespace Prueba.Pages
{
    public class EditModel : PageModel
    {
        private readonly Prueba.Data.PruebaContext _context;

        public EditModel(Prueba.Data.PruebaContext context)
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

            var persona =  await _context.Persona.FirstOrDefaultAsync(m => m.ID == id);
            if (persona == null)
            {
                return NotFound();
            }
            Persona = persona;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(Persona.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PersonaExists(int id)
        {
          return (_context.Persona?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

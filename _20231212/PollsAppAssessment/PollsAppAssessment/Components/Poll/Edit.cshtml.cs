using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PollsAppAssessment.Data;
using PollsAppAssessment.Models;

namespace PollsAppAssessment.Components.Poll
{
    public class EditModel : PageModel
    {
        private readonly PollsAppAssessment.Data.ApplicationDbContext _context;

        public EditModel(PollsAppAssessment.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Poll Poll { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poll =  await _context.Poll.FirstOrDefaultAsync(m => m.Id == id);
            if (poll == null)
            {
                return NotFound();
            }
            Poll = poll;
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

            _context.Attach(Poll).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PollExists(Poll.Id))
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

        private bool PollExists(int id)
        {
            return _context.Poll.Any(e => e.Id == id);
        }
    }
}

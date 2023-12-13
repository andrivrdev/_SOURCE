using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PollsAppAssessment.Data;
using PollsAppAssessment.Models;

namespace PollsAppAssessment.Components.Poll
{
    public class DeleteModel : PageModel
    {
        private readonly PollsAppAssessment.Data.ApplicationDbContext _context;

        public DeleteModel(PollsAppAssessment.Data.ApplicationDbContext context)
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

            var poll = await _context.Poll.FirstOrDefaultAsync(m => m.Id == id);

            if (poll == null)
            {
                return NotFound();
            }
            else
            {
                Poll = poll;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poll = await _context.Poll.FindAsync(id);
            if (poll != null)
            {
                Poll = poll;
                _context.Poll.Remove(Poll);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

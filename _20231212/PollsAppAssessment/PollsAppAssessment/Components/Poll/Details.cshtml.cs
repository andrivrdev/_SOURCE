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
    public class DetailsModel : PageModel
    {
        private readonly PollsAppAssessment.Data.ApplicationDbContext _context;

        public DetailsModel(PollsAppAssessment.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}

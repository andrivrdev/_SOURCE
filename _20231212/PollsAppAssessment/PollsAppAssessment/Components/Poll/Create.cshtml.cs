using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PollsAppAssessment.Data;
using PollsAppAssessment.Models;

namespace PollsAppAssessment.Components.Poll
{
    public class CreateModel : PageModel
    {
        private readonly PollsAppAssessment.Data.ApplicationDbContext _context;

        public CreateModel(PollsAppAssessment.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Poll Poll { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Poll.Add(Poll);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

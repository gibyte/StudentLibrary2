using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentLibrary2.Data;
using StudentLibrary2.Model;

namespace StudentLibrary2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Book? Book { get; set; }

        public IActionResult OnGet(int id)
        {
            Book = _context.Books
                        .Where(c => c.Id == id)
                        .Include(b => b.Author)
                        .FirstOrDefault();

            if (Book == null)
                return NotFound();

            return Page();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public Book Book { get; set; }

        public IActionResult OnGet(int id)
        {
            Book = _context.Books.FirstOrDefault(b => b.Id == id);

            if (Book == null)
                return NotFound();

            return Page();
        }
    }
}

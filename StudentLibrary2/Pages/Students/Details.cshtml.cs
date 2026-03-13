using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentLibrary2.Data;
using StudentLibrary2.Model;

namespace StudentLibrary2.Pages.Students
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public IActionResult OnGet(int id)
        {
            Student = _context.Students.FirstOrDefault(s => s.Id == id);

            if (Student == null)
                return NotFound();

            return Page();
        }
    }
}

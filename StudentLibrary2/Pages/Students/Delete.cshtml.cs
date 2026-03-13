using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentLibrary2.Data;
using StudentLibrary2.Model;

namespace StudentLibrary2.Pages.Students
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public IActionResult OnGet(int id)
        {
            Student = _context.Students.Find(id);

            if (Student == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            var student = _context.Students.Find(Student.Id);

            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}


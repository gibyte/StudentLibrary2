using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentLibrary2.Data;
using StudentLibrary2.Model;

namespace StudentLibrary2.Pages.Students
{
    //[Authorize]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        async public Task<IActionResult> OnGet(int id)
        {

            if (id <= 0)
                throw new ArgumentException("Id должен быть положительным");

            Student = await _context.Students.FindAsync(id);

            //id = id / 0;

            if (Student == null)
                return NotFound();

            return Page();

        }

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
                return Page();

            _context.Students.Update(Student);
            _context.SaveChanges();

            return RedirectToPage("Index");
        }
    }
}

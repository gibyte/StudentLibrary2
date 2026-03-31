using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentLibrary2.Data;
using StudentLibrary2.Model;

namespace StudentLibrary2.Pages.Students
{
    //[Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
                public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }
        public void OnGet() { }
        async public Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }

    }
}

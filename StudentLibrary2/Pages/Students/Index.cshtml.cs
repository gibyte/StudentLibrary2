using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentLibrary2.Data;
using StudentLibrary2.Model;

namespace StudentLibrary2.Pages.Students
{

    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Student> Students { get; set; }

        public void OnGet()
        {
            Students = _context.Students.ToList();
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentLibrary2.Data;
using StudentLibrary2.Model.AuthApp;

namespace StudentLibrary2.Pages.Account.Users
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AuthUser User { get; set; }

        [BindProperty]
        public IFormFile? AvatarFile { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            User = await _context.AuthUsers.FindAsync(id);

            if (User == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            if (AvatarFile != null)
            {
                if (AvatarFile.Length > 2 * 1024 * 1024) // проверка на размер фала
                {
                    ModelState.AddModelError("", "File too large");
                    return Page();
                }

                using (var ms = new MemoryStream())
                {
                    await AvatarFile.CopyToAsync(ms);
                    User.Avatar = ms.ToArray();
                }
            }

            _context.Attach(User).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}

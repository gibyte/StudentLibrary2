using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using StudentLibrary2.Data;
using StudentLibrary2.Hubs;
using StudentLibrary2.Model;

namespace StudentLibrary2.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<BookHub> _hubContext;

        public EditModel(ApplicationDbContext context, IHubContext<BookHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [BindProperty]
        public Book? Book { get; set; }

        public IActionResult OnGet(int id)
        {
            Book = _context.Books
                        .Where( c=> c.Id == id)
                        .Include(b => b.Author)
                        .FirstOrDefault();

            if (Book == null)
                return NotFound();

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Books.Update(Book);
            _context.SaveChanges();

            // Отправляем обновление всем клиентам
            _hubContext.Clients.All.SendAsync("BookUpdated", Book);

            return RedirectToPage("Index");
        }
    }
}

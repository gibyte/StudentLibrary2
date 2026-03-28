using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudentLibrary2.Pages
{
    public class ChatModel : PageModel
    {
        public string UserName { get; set; } = "Аноним";

        public void OnGet()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                UserName = User.Identity.Name!;
            }
        }

    }
}

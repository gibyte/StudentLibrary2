using Microsoft.AspNetCore.SignalR;
using StudentLibrary2.Model;

namespace StudentLibrary2.Hubs
{
    public class BookHub : Hub
    {
        // Отправка обновления книги всем клиентам
        public async Task SendBookUpdate(Book book)
        {
            await Clients.All.SendAsync("BookUpdated", book);
        }
    }
}

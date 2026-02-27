namespace StudentLibrary2.Model
{
    public class Author : EFModel
    {
        public List<Book> Books { get; set; } = new List<Book>();
    }
}

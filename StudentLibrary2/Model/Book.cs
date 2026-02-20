namespace StudentLibrary2.Model
{
    public class Book : EFModel
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public int AuthorID { get; set; }
        public int Year { get; set; }
        public int Copies { get; set; }
    }
}

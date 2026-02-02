namespace StudentLibrary2.Model
{
    public class Book : EFModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Copies { get; set; }
    }
}

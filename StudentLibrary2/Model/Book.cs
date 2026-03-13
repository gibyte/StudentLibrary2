using System.Text.Json.Serialization;

namespace StudentLibrary2.Model
{
    public class Book : EFModel
    {
        public string Title { get; set; } = "";
        [JsonIgnore]
        public Author Author { get; set; } = new();
        public int AuthorID { get; set; }
        public int Year { get; set; }
        public int Copies { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StudentLibrary2.Model
{
    public class Book : EFModel
    {
        public string Title { get; set; } = "";
        [Required(ErrorMessage = "Требуется автор.")]
        [JsonIgnore]
        public Author Author { get; set; } = new();
        public int AuthorID { get; set; }
        [Range(1000, 2100, ErrorMessage = "Год должен быть между 1000 и 2100.")]
        public int Year { get; set; }
        public int Copies { get; set; }
    }
}

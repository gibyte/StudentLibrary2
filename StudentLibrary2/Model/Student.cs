using System.ComponentModel.DataAnnotations;

namespace StudentLibrary2.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }
        //email
    }
}

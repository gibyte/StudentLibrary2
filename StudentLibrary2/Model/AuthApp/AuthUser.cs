namespace StudentLibrary2.Model.AuthApp
{
    public class AuthUser : EFModel
    {
        public string Email { get; set; }
        public new string Name { get; set; } = "Name";
        public string Password { get; set; }
        public string Role { get; set; }
        public byte[]? Avatar { get; set; }
    }
}

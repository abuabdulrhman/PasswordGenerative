namespace PasswordGenerative.Models
{
    public class PasswordModel
    {
        public int Length { get; set; } = 10; // default length
        public string GeneratedPassword { get; set; }
    }
}

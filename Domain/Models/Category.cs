namespace Domain.Models
{
    public class Category
    {
        public Guid CategoryId { get; set; }         // Primärnyckel
        public Guid UserId { get; set; }             // Foreign key till användare
        public string Name { get; set; } = string.Empty;

        //Navigation property – länkar till användaren som äger kategorin
        public User? User { get; set; }
    }
}

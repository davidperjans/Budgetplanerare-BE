namespace Domain.Moduls;

//Här definierar vi klassen User
// vi ska lägga till userid, user name, email, passwordhash, currency, 
public class User
{
    public Guid UserId { get; set; } 
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public Guid? DefaultCategoryId { get; set; }
    
    //Navigation property
    
   // public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
   // public ICollection<Category> Categories { get; set; } = new List<Category>();
}


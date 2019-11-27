namespace Auction_House_WCF.Models
{
    public interface IPerson
    {
        int Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string PasswordHash { get; set; }
        string Salt { get; set; }

    }
}
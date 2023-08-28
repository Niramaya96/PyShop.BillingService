using Billing;

namespace PyShop.BillingService.Services
{
    public class User
    {
        public User(string name,int amount,int rating)
        {
            Name = name;
            Amount = amount;
            Rating = rating;
        }
        public string Name { get; set; } 
        public int Amount { get; set; }
        public int Rating { get; set; }
    }
}

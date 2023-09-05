using Billing;

namespace PyShop.BillingService.Services
{
    public class User
    {
        public User(string name,int rating)
        {
            Name = name;
            Rating = rating;
        }
        public string Name { get; set; } 
        public int Amount { get => Coins.Count;}
        public int Rating { get; set; }
        public List<Coin> Coins { get; set; } = new List<Coin>();
    }
}

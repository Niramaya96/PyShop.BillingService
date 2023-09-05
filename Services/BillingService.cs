using Grpc.Core;
using PyShop.BillingService.Services;

namespace Billing
{
    public class BillingService : Billing.BillingBase
    {
        private List<User> Users;
        public BillingService()
        {
          Users = new List<User>()
           {
              new User("boris",5000),
              new User("maria",1000),
              new User("oleg",800)
           };
        }

        public override async Task<Response> CoinsEmission(EmissionAmount request, ServerCallContext context)
        {
           
           var totalRating = Users.Select(x => x.Rating).Sum();
            var lastIndex = 0;
           for(var i = 0; i < Users.Count; i++) 
           { 
                var user = Users[i];
                var coinsCount = (int)Math.Round((double)user.Rating / totalRating * request.Amount);
                for (int j = 0; j < coinsCount; j++)
                {
                    user.Coins.Add(new Coin() { Id = lastIndex, History = $"Emission:{user.Name}" });
                    lastIndex++;
                }
           }
            return await Task.FromResult(new Response() { Status = Response.Types.Status.Ok, Comment = $"EmissionComplete" });
        }
        public override Task<Response> MoveCoins(MoveCoinsTransaction request, ServerCallContext context)
        {
            var dst_user = Users.Find(u => u.Name == request.DstUser);
            var src_user = Users.Find(u => u.Name == request.SrcUser);
            if (dst_user != null && src_user != null)
            {
                if (true)
                {

                }
            }
            return base.MoveCoins(request, context);
        }
        public override async Task ListUsers(None request, IServerStreamWriter<UserProfile> responseStream, ServerCallContext context)
        {
            foreach (User user in Users)
            {
                var userProfile = new UserProfile() { Name = user.Name, Amount = user.Amount };
                await responseStream.WriteAsync(userProfile);
            }
        }
        public override Task<Coin> LongestHistoryCoin(None request, ServerCallContext context)
        {
            return base.LongestHistoryCoin(request, context);
        }
    }

}

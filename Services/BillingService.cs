using Grpc.Core;

namespace Billing
{
    public class BillingService : Billing.BillingBase
    {
        private List<UserProfile> Users = new List<UserProfile>()
        { new UserProfile() { Name = "Boris",Amount=0},
          new UserProfile() { Name="Maria",Amount = 0},
          new UserProfile() {Name="Oleg",Amount=0}};
        public override Task<Response> CoinsEmission(EmissionAmount request, ServerCallContext context)
        {
            return base.CoinsEmission(request, context);
        }
        public override Task<Response> MoveCoins(MoveCoinsTransaction request, ServerCallContext context)
        {
            return base.MoveCoins(request, context);
        }
        public override async Task ListUsers(None request, IServerStreamWriter<UserProfile> responseStream, ServerCallContext context)
        {
            foreach (UserProfile user in Users)
            { 
                await responseStream.WriteAsync(user);
            }
        }
        public override Task<Coin> LongestHistoryCoin(None request, ServerCallContext context)
        {
            return base.LongestHistoryCoin(request, context);
        }
    }

}

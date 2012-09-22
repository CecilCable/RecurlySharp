using System.Linq;

namespace RecurlySharp.DTO{
    public static class SubscriptionExtenstions{
        public static string AccountCode(this Subscription subscription){
            if(subscription == null){
                return null;
            }
            if(subscription.Account == null){
                return null;
            }
            if(subscription.Account.Href == null){
                return null;
            }
            var split = subscription.Account.Href.Split('/');
            //should return null of zero array
            return split.LastOrDefault();
        }
    }
}
using System.Collections.Generic;
using RecurlySharp.DTO;
using RestSharp;

namespace RecurlySharp{
    public class RecurlyClient{
        private readonly RestClient _client;

        public RecurlyClient(string apiKey){
            _client = new RestClient("https://api.recurly.com/") { Authenticator = new HttpBasicAuthenticator(apiKey, "") };
        }

        /// <summary>
        ///   URL is https://api.recurly.com/v2/recurly_js/result/{recurly_token}
        /// </summary>
        /// <param name="recurlyToken"> </param>
        /// <returns> </returns>
        public Subscription GetByToken(string recurlyToken){
            var request = new RestRequest("v2/recurly_js/result/{recurly_token}");
            request.AddUrlSegment("recurly_token", recurlyToken);
            var response = _client.Execute<Subscription>(request);
            return response.Data;
        }


        /// <summary>
        /// </summary>
        /// <param name="uuid"> </param>
        /// <returns> </returns>
        public Subscription GetByUuid(string uuid){
            //https://api.recurly.com/v2/subscriptions/:uuid
            var request = new RestRequest("v2/subscriptions/{uuid}");
            request.AddUrlSegment("uuid", uuid);
            var response = _client.Execute<Subscription>(request);
            return response.Data;
        }

        public void CreateSubscription(string xml){
            //https://api.recurly.com/v2/subscriptions
            var request = new RestRequest("v2/subscriptions", Method.POST);
            request.AddParameter("", xml, ParameterType.RequestBody);
            var response = _client.Execute(request);
            if(response.ErrorException != null){
                throw response.ErrorException;
            }
        }

        public T PostXml<T>(string url, string body) where T : new(){
            var request = new RestRequest(url, Method.POST);
            request.AddParameter("", body, ParameterType.RequestBody);
            var response = _client.Execute<T>(request);


            if(response.ErrorException != null){
                throw response.ErrorException;
            }
            return response.Data;
        }

        public string PostPone(string uuid, string newnewalDate){
            var request = new RestRequest("v2/subscriptions/{uuid}/postpone?next_renewal_date={next_renewal_date}", Method.PUT);
            request.AddUrlSegment("uuid", uuid);
            request.AddUrlSegment("next_renewal_date", newnewalDate);
            var response = _client.Execute(request);
            if(response.ErrorException != null){
                throw response.ErrorException;
            }
            return response.Content;
        }

        public List<Subscription> GetSubscriptions(string accountCode){
            //https://api.recurly.com/v2/accounts/:account_code/subscriptions
            var request = new RestRequest("v2/accounts/{account_code}/subscriptions");
            request.AddUrlSegment("account_code", accountCode);
            var response = _client.Execute<List<Subscription>>(request);

            if(response.ErrorException != null){
                throw response.ErrorException;
            }
            return response.Data;
        }

        public Account GetByAccount(string accountCode){
            if(string.IsNullOrEmpty(accountCode)){
                return null;
            }
            //https://api.recurly.com/v2/accounts/:account_code
            var request = new RestRequest("v2/accounts/{account_code}");
            request.AddUrlSegment("account_code", accountCode);
            var response = _client.Execute<Account>(request);

            if(response.ErrorException != null){
                throw response.ErrorException;
            }
            return response.Data;
        }
    }
}
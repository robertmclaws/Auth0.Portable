using Auth0.Core;
using PortableRest;
using System.Threading.Tasks;

namespace Auth0.RestClient
{

    /// <summary>
    /// 
    /// </summary>
    public class ApiClient : PortableRest.RestClient
    {

        #region Properties



        #endregion

        #region Constructors

        /// <summary>
        /// The default constructor for a new instance of the ApiClient.
        /// </summary>
        /// <param name="accountName">The base subdomain for your account. For example, {YOURDOMAINHERE}.auth0.com.</param>
        public ApiClient(string accountName)
        {
            BaseUrl = string.Format("https://{accountName}.auth0.com/", accountName);
        }

        #endregion

        #region Authentication API

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DelegatedTokenBase> GetDelegationToken(DelegationRequestBase request)
        {
            var isIdToken = request is IdTokenDelegationRequest;
            DelegatedTokenBase token = null;

            var clientRequest = new RestRequest(BaseUrl + "delegation") { ContentType = ContentTypes.Json };
            clientRequest.AddParameter(request);

            if (isIdToken)
            {
                var result = await SendAsync<DelegatedIdToken>(clientRequest);
                if (result.HttpResponseMessage != null && result.HttpResponseMessage.IsSuccessStatusCode)
                {
                    token = result.Content;
                }
            }
            else
            {
                var result = await SendAsync<DelegatedRefreshToken>(clientRequest);
                if (result.HttpResponseMessage != null && result.HttpResponseMessage.IsSuccessStatusCode)
                {
                    token = result.Content;
                }
            }
            return token;

        }

        #endregion

    }
}
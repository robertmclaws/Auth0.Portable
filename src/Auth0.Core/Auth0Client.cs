using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auth0.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Auth0.Api
{
    public class Auth0Client
    {

        /// <summary>
        /// The name of the client. Must contain at least one character. Does not allow '&lt;' or '&gt;'.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The secret used to sign tokens for the client.
        /// </summary>
        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// A set of URLs that are valid to call back from Auth0 when authenticating users.
        /// </summary>
        [JsonProperty("callbacks")]
        public string[] Callbacks { get; set; }

        /// <summary>
        /// A set of URLs that represents valid origins for CORS.
        /// </summary>
        [JsonProperty("allowed_origins")]
        public string[] AllowedOrigins { get; set; }

        /// <summary>
        /// List of audiences for SAML protocol.
        /// </summary>
        [JsonProperty("client_aliases")]
        public string[] ClientAliases { get; set; }

        /// <summary>
        /// Ids of clients that will be allowed to perform delegation requests. Clients that will be allowed to make delegation request. 
        /// </summary>
        /// <remarks>
        /// By default, all your clients will be allowed. This field allows you to specify specific clients.
        /// </remarks>
        [JsonProperty("allowed_clients")]
        public string[] AllowedClients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("jwt_configuration")]
        public JwtConfiguration JwtConfiguration { get; set; }

        /// <summary>
        /// Client signing keys.
        /// </summary>
        [JsonProperty("signing_keys")]
        public SigningKeys[] SigningKeys { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("encryption_key")]
        public EncryptionKey EncryptionKey { get; set; }

        /// <summary>
        /// true to use Auth0 instead of the IdP to do Single Sign On, false otherwise.
        /// </summary>
        [JsonProperty("sso")]
        public bool Sso { get; set; }

        /// <summary>
        /// true if the custom login page is not to be used, false otherwise.
        /// </summary>
        [JsonProperty("custom_login_page_off")]
        public bool custom_login_page_off { get; set; }

        /// <summary>
        /// The content (HTML, CSS, JS) of the custom login page.
        /// </summary>
        [JsonProperty("jwt_configuration")]
        public string custom_login_page { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("jwt_configuration")]
        public string custom_login_page_preview { get; set; }

        /// <summary>
        /// Form template for WS-Federation protocol.
        /// </summary>
        [JsonProperty("form_template")]
        public string WsFedFormTemplate { get; set; }

        /// <summary>
        /// True if the client is a heroku application, false otherwise.
        /// </summary>
        [JsonProperty("jwt_configuration")]
        public bool is_heroku_app { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("addons")]
        public Addons AddOns { get; set; }


    }
}
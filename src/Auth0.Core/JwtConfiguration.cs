using Newtonsoft.Json;

namespace Auth0.Core
{

    /// <summary>
    /// 
    /// </summary>
    public class JwtConfiguration
    {

        /// <summary>
        /// The amount of time (in seconds) that the token will be valid after being issued.
        /// </summary>
        [JsonProperty("lifetime_in_seconds")]
        public int LifetimeInSeconds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("secret_encoded")]
        public bool IsSecretEncoded { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("scopes")]
        public Scopes Scopes { get; set; }

        /// <summary>
        ///  The algorithm used to sign the JsonWebToken. Possible values are 'HS256' or 'RS256'. 
        /// </summary>
        [JsonProperty("alg")]
        public string SigningAlgorithm { get; set; }
    }
}
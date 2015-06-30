using Newtonsoft.Json;

namespace Auth0.Core
{

    /// <summary>
    /// 
    /// </summary>
    public class SigningKeys
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cert")]
        public string Cert { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("key")]
        public string Key { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("pkcs7")]
        public string Pkcs7 { get; set; }
    }
}
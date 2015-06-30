using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Auth0.Core
{
    public class IdTokenDelegationRequest : DelegationRequestBase
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("id_token")]
        public string IdToken { get; set; }


    }
}

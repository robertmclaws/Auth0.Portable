using Newtonsoft.Json;

namespace Auth0.Core
{

    /// <summary>
    /// 
    /// </summary>
    public class Addons
    {

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("aws")]
        public dynamic AmazonWebServices { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("wams")]
        public dynamic AzureMobileServices { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("azure_sb")]
        public dynamic AzureServiceBus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("box")]
        public dynamic Box { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("cloudbees")]
        public dynamic CloudBees { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("concur")]
        public dynamic Concur { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("dropbox")]
        public dynamic DropBox { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("echosign")]
        public dynamic EchoSign { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("egnyte")]
        public dynamic Egnyte { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("firebase")]
        public dynamic FireBase { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("newrelic")]
        public dynamic NewRelic { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("office365")]
        public dynamic Office365 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("salesforce")]
        public dynamic SalesForce { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("salesforce_api")]
        public dynamic SalesForceApi { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("salesforce_sandbox_api")]
        public dynamic SalesForceSandboxApi { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("samlp")]
        public dynamic SamlP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sap_api")]
        public dynamic SapApi { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("sharepoint")]
        public dynamic SharePoint { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("springcm")]
        public dynamic SpringCM { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("webapi")]
        public dynamic WebApi { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("wsfed")]
        public dynamic WsFed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("zendesk")]
        public dynamic ZenDesk { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("zoom")]
        public dynamic Zoom { get; set; }
    }
}
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Auth0.Claims;
using FluentAssertions;
using System.Linq;
using System.Security.Claims;

namespace Auth0.Tests.Claims
{
    [TestClass]
    public class ClaimsManagerTests
    {

        #region TestData

        private string test1 = "{\"_id\": \"ebd99cb9f4950c55vb299303030b9999\",    \"email\": \"test@test.com\",  " +
            "  \"emails\": [        \"test@test.com\"    ],    \"family_name\": \"User\",    \"giv" +
            "en_name\": \"Test\",    \"locale\": \"en_US\",    \"name\": \"TestUser\",    \"nickname\":" +
            " \"test@test.com\",    \"picture\": \"https://apis.live.net/v5.0/72b650e640e197b2/pi" +
            "cture\",    \"link\": \"https://profile.live.com/\",    \"work\": [],    \"addresses\"" +
            ": {        \"personal\": {            \"street\": null,            \"street_2\": nu" +
            "ll,            \"city\": null,            \"state\": null,            \"postal_cod" +
            "e\": null,            \"region\": null        },        \"business\": {          " +
            "  \"street\": null,            \"street_2\": null,            \"city\": null,      " +
            "      \"state\": null,            \"postal_code\": null,            \"region\": null" +
            "        }    },    \"updated_time\": \"2015-06-30T01:25:25+0000\",    \"birth_day" +
            "\": 7,    \"birth_month\": 7,    \"birth_year\": 1977,    \"app_metadata\": {      " +
            "  \"email\": \"test@test.com\",        \"emails\": [            \"test@test.com\"    " +
            "    ],        \"family_name\": \"User\",        \"given_name\": \"Test\",        \"nam" +
            "e\": \"Test User\",        \"nickname\": \"test@test.com\",        \"picture\": \"https:" +
            "//apis.live.net/v5.0/99b888e640e197/picture\",    },    \"clientID\": \"YOURCLIENT" +
            "ID\",    \"identities\": [        {            \"access_token\": \"SOMETOKEN\",    " +
            "        \"provider\": \"windowslive\",            \"user_id\": \"99b888e640e197\",    " +
            "        \"connection\": \"windowslive\",            \"isSocial\": true        }    " +
            "],    \"user_id\": \"windowslive|99b888e640e197\",    \"email_verified\": true,    " +
            "\"updated_at\": \"2015-06-30T20:43:47.602Z\",    \"iss\": \"https://auth0test.auth0.co" +
            "m/\",    \"sub\": \"windowslive|99b888e640e197\",    \"aud\": \"YOURCLIENTID\",    \"ex" +
            "p\": 1435733028,    \"iat\": 1435697028}";

        #endregion


        [TestMethod]
        public void GetClaimsFromJwt()
        {
            var claims = ClaimsManager.GetClaimsFromPayload(test1, "https://auth0test.auth0.com/");
            claims.Should().NotBeNullOrEmpty();
            claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Should().NotBeNull();
            claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Should().NotBeNull();
            claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname).Should().NotBeNull();
            claims.FirstOrDefault(c => c.Type == ClaimTypes.Expiration).Should().NotBeNull();
            claims.FirstOrDefault(c => c.Type == ClaimTypes.X500DistinguishedName).Should().BeNull();
        }
    }
}

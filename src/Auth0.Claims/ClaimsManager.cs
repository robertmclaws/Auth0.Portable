using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Auth0.Claims
{

    /// <summary>
    /// 
    /// </summary>
    public class ClaimsManager
    {

        #region Constants

        private const string DefaultIssuer = "LOCAL AUTHORITY";
        private const string StringClaimValueType = "http://www.w3.org/2001/XMLSchema#string";

        #endregion

        #region Private Members

        // sort claim types by relevance
        private static readonly string[] ClaimTypesForUserId = { "userid" };
        private static readonly string[] ClaimTypesForRoles = { "roles", "role" };
        private static readonly string[] ClaimTypesForEmail = { "emails", "email" };
        private static readonly string[] ClaimTypesForGivenName = { "givenname", "firstname" };
        private static readonly string[] ClaimTypesForFamilyName = { "familyname", "lastname", "surname" };
        private static readonly string[] ClaimTypesForPostalCode = { "postalcode" };
        private static readonly string[] ClaimsToExclude = { "iss", "sub", "aud", "iat", "identities" };

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets a <see cref="List{Claim}"/> for a given payload. The Payload could be a JWT, or the result of an Auth0 API call.
        /// </summary>
        /// <returns>As <see cref="List{Claim}"/> with the claims from a given payload.</returns>
        public static List<Claim> GetClaimsFromPayload(string jwt, string issuer)
        {
            var payloadData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jwt);

            //RWM: Should we validate this here, or assume it will be validated somewhere else?
            object iss;
            if (payloadData.TryGetValue("iss", out iss))
            {
                if (!string.IsNullOrEmpty(issuer))
                {
                    if (!iss.ToString().Equals(issuer, StringComparison.Ordinal))
                    {
                        throw new TokenValidationException(
                            string.Format("Token issuer mismatch. Expected: '{0}' and got: '{1}'", issuer, iss));
                    }
                }
                else
                {
                    // if issuer is not specified, set issuer with jwt[iss]
                    issuer = iss.ToString();
                }
            }

            var claims = ExtractClaimsFromDictionary(payloadData, issuer);
            return claims;
        }

        /// <summary>
        /// Gets a <see cref="ClaimsIdentity"/> properly populated with the claims passed to it.
        /// </summary>
        /// <param name="claims">The list of claims that we've already processed.</param>
        /// <param name="issuer">The principal that issued the JWT.</param>
        /// <returns></returns>
        public static ClaimsIdentity GetClaimsIdentity(IEnumerable<Claim> claims, string issuer)
        {
            var subject = new ClaimsIdentity("Federation", ClaimTypes.Name, ClaimTypes.Role);

            foreach (var claim in claims)
            {
                var type = claim.Type;
                if (type == ClaimTypes.Actor)
                {
                    if (subject.Actor != null)
                    {
                        throw new InvalidOperationException(string.Format(
                            "Jwt10401: Only a single 'Actor' is supported. Found second claim of type: '{0}', value: '{1}'", new object[] { "actor", claim.Value }));
                    }
                }

                var newClaim = new Claim(type, claim.Value, claim.ValueType, issuer, issuer, subject);
                subject.AddClaim(newClaim);
            }

            return subject;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets a List of Claims from a given deserialized JSON token.
        /// </summary>
        /// <param name="jwtData">The deserialized JSON payload to process.</param>
        /// <param name="issuer">The principal that issued the JWT.</param>
        /// <returns>A List of Claims derived from the JWT.</returns>
        private static List<Claim> ExtractClaimsFromDictionary(Dictionary<string, object> jwtData, string issuer)
        {
            var list = new List<Claim>();
            issuer = issuer ?? DefaultIssuer;

            foreach (var pair in jwtData)
            {
                var claimType = GetClaimType(pair.Key);
                var source = pair.Value as List<object>;

                if (source != null)
                {
                    // Get the claim, check to make sure it hasn't already been added. This is a workaround
                    // for an issue where MicrosoftAccounts return the same e-mail address twice.
                    foreach (var innerClaim in source.Cast<object>().Select(item => new Claim(claimType, item.ToString(), StringClaimValueType, issuer, issuer))
                        .Where(innerClaim => !list.Any(c => c.Type == innerClaim.Type && c.Value == innerClaim.Value)))
                    {
                        list.Add(innerClaim);
                    }

                    continue;
                }

                var claim = new Claim(claimType, pair.Value.ToString(), StringClaimValueType, issuer, issuer);
                if (!list.Contains(claim))
                {
                    list.Add(claim);
                }
            }

            // dont include specific jwt claims
            return list.Where(c => ClaimsToExclude.All(t => t != c.Type)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static string GetClaimType(string name)
        {
            var newName = name.Replace("_", "").ToLower();
            if (newName == "name")
            {
                return ClaimTypes.Name;
            }
            if (ClaimTypesForUserId.Contains(newName))
            {
                return ClaimTypes.NameIdentifier;
            }
            if (ClaimTypesForRoles.Contains(newName))
            {
                return ClaimTypes.Role;
            }
            if (ClaimTypesForEmail.Contains(newName))
            {
                return ClaimTypes.Email;
            }
            if (ClaimTypesForGivenName.Contains(newName))
            {
                return ClaimTypes.GivenName;
            }
            if (ClaimTypesForFamilyName.Contains(newName))
            {
                return ClaimTypes.Surname;
            }
            if (ClaimTypesForPostalCode.Contains(newName))
            {
                return ClaimTypes.PostalCode;
            }
            if (name == "gender")
            {
                return ClaimTypes.Gender;
            }
            if (name == "exp")
            {
                return ClaimTypes.Expiration;
            }

            return name;
        }

        /// <summary>
        /// Converts a Unix timestring to a .NET DateTime instance.
        /// </summary>
        /// <param name="unixTime">The Unix timestring to convert.</param>
        /// <returns>A <see cref="DateTime"/> instance from the given Unix timestring.</returns>
        private static DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }

        #endregion

    }

    /// <summary>
    /// Represents an error with validating the JSON Web Token.
    /// </summary>
    public class TokenValidationException : Exception
    {
        public TokenValidationException(string message)
            : base(message)
        {
        }
    }

}
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcClient.MiddleWares
{
    public class ClaimsTransformer : IClaimsTransformation
    {
        private readonly IHttpContextAccessor _httpAccessor;
        public ClaimsTransformer(IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
        }
        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            if (principal.Identity.IsAuthenticated)
            {
                var access_token = _httpAccessor.HttpContext.Items["access_token"] as string;
                //var test = (await _httpAccessor.HttpContext.AuthenticateAsync()).Properties.Items;
                //var test2 = test.FirstOrDefault(t => t.Key == "");


                //// get this from cache or db
                //var country = "Pakistan";
                //(principal.Identity as ClaimsIdentity).AddClaim(new Claim("Nationality", country));
                ////var accessToken = _httpAccessor.HttpContext.GetTokenAsync("access_token").Result;
                //var client = new HttpClient();
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
                //var content = client.GetStringAsync("https://localhost:44366/identity").Result;
                //var claimList = JsonConvert.DeserializeObject<IList<Claim>>(content);
            }
            try
            {
               

            }
            catch (Exception ex)
            {
                var test = 1;
            }
            principal.Identities.First().AddClaim(new Claim("now", DateTime.Now.ToString()));

            return principal;
        }
    }
}

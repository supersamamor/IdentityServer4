namespace MvcClient.Configuration
{
    public class AdminConfiguration
    {       
        public string[] Scopes { get; set; }     
        public bool RequireHttpsMetadata { get; set; }
        public string IdentityAdminCookieName { get; set; }     
        public string TokenValidationClaimName { get; set; }
        public string TokenValidationClaimRole { get; set; }
        public string IdentityServerBaseUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string OidcResponseType { get; set; }    
    }
}

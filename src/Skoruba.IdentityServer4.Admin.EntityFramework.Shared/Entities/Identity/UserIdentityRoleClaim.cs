using Microsoft.AspNetCore.Identity;
using Skoruba.IdentityServer4.Admin.EntityFramework.Identity.Models;

namespace Skoruba.IdentityServer4.Admin.EntityFramework.Shared.Entities.Identity
{
    public class UserIdentityRoleClaim : IdentityRoleClaim<string>
    {
        public int? ApplicationId { get; set; }
        public string Permission { get; set; }
        public string Module { get; set; }
        public Application Application { get; set; }
    }
}
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace Skoruba.IdentityServer4.Admin.UI
{
    public static class Constants
    {
        public static readonly List<SelectListItem> Permissions =
            new()
            {
                new SelectListItem { Value = "Create", Text = "Create" },
                new SelectListItem { Value = "View", Text = "View" },
                new SelectListItem { Value = "Edit", Text = "Edit" },
                new SelectListItem { Value = "Delete", Text = "Delete" },
            };

        public static string PermissionClaimType = "Permissions";
        public static string PermissionClaimValueFiller = "ClaimValue";
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces
{
    public interface IRoleClaimsDto : IRoleClaimDto
    {
        string RoleName { get; set; }
        List<IRoleClaimDto> Claims { get; }
        int TotalCount { get; set; }
        int PageSize { get; set; }
        int ApplicationId { get; set; }
        string Permission { get; set; }
        IEnumerable<SelectListItem> ApplicationList { get; set; }
    }
}

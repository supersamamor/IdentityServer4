using Microsoft.AspNetCore.Mvc.Rendering;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity
{
    public class RoleClaimsDto<TRoleClaimDto, TKey> : RoleClaimDto<TKey>, IRoleClaimsDto
        where TRoleClaimDto : RoleClaimDto<TKey>
    {
        public RoleClaimsDto()
        {
            Claims = new List<TRoleClaimDto>();
        }

        public string RoleName { get; set; }

        public List<TRoleClaimDto> Claims { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
        public int ApplicationId { get; set; }
        public string Permission { get; set; }
        public string Module { get; set; }     
        List<IRoleClaimDto> IRoleClaimsDto.Claims => Claims.Cast<IRoleClaimDto>().ToList();
        public IEnumerable<SelectListItem> ApplicationList { get; set; }
    }
}

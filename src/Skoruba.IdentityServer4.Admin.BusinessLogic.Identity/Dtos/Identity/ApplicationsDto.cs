using Skoruba.IdentityServer4.Admin.EntityFramework.Identity.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity
{
    public class ApplicationsDto
    {
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<IApplication> Applications { get; set; }
    }
}

using System;
namespace Skoruba.IdentityServer4.Admin.EntityFramework.Identity.Repositories.Interfaces
{
    public interface IApplication
    {       
        int Id { get; set; }
        string Name { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
        string CreatedByUsername { get; set; }
        string UpdatedByUsername { get; set; }
    }
}

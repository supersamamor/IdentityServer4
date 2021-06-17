using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity
{
    public class ApplicationsRequestedEvent<TApplicationsDto> : AuditEvent
    {
        public TApplicationsDto Applications { get; set; }

        public ApplicationsRequestedEvent(TApplicationsDto applications)
        {
            Applications = applications;
        }
    }
}

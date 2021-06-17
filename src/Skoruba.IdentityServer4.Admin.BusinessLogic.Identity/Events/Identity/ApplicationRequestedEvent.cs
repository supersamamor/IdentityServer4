using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity
{
    public class ApplicationRequestedEvent : AuditEvent
    {
        public ApplicationDto Application { get; set; }

        public ApplicationRequestedEvent(ApplicationDto application)
        {
            Application = application;
        }
    }
}

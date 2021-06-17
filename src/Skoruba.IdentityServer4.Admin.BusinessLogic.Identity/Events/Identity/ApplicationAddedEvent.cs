using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity
{
    public class ApplicationAddedEvent : AuditEvent
    {
        public ApplicationDto Application { get; set; }

        public ApplicationAddedEvent(ApplicationDto application)
        {
            Application = application;
        }
    }
}

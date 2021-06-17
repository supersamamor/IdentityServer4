using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity;


namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity
{  
    public class ApplicationUpdatedEvent : AuditEvent
    {
        public ApplicationDto Application { get; set; }

        public ApplicationUpdatedEvent(ApplicationDto application)
        {
            Application = application;
        }
    }
}

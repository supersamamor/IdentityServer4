using Skoruba.AuditLogging.Events;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity;

namespace Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Events.Identity
{   
    public class ApplicationDeletedEvent : AuditEvent
    {
        public ApplicationDto Application { get; set; }

        public ApplicationDeletedEvent(ApplicationDto application)
        {
            Application = application;
        }
    }
}

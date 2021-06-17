using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Services.Interfaces;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Shared.Dtos.Common;
using Skoruba.IdentityServer4.Admin.UI.Configuration.Constants;
using Skoruba.IdentityServer4.Admin.UI.ExceptionHandling;
using Skoruba.IdentityServer4.Admin.UI.Helpers.Localization;

namespace Skoruba.IdentityServer4.Admin.UI.Areas.AdminUI.Controllers
{
    [Authorize(Policy = AuthorizationConsts.AdministrationPolicy)]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Area(CommonConsts.AdminUIArea)]
    public class ApplicationController<TUserDto, TRoleDto, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
            TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
            TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto, TApplication, TApplicationsDto> : BaseController
        where TUserDto : UserDto<TKey>, new()
        where TRoleDto : RoleDto<TKey>, new()
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TUserLogin : IdentityUserLogin<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
        where TUserToken : IdentityUserToken<TKey>
        where TUsersDto : UsersDto<TUserDto, TKey>
        where TRolesDto : RolesDto<TRoleDto, TKey>
        where TUserRolesDto : UserRolesDto<TRoleDto, TKey>
        where TUserClaimsDto : UserClaimsDto<TUserClaimDto, TKey>
        where TUserProviderDto : UserProviderDto<TKey>
        where TUserProvidersDto : UserProvidersDto<TUserProviderDto, TKey>
        where TUserChangePasswordDto : UserChangePasswordDto<TKey>
        where TRoleClaimsDto : RoleClaimsDto<TRoleClaimDto, TKey>
        where TUserClaimDto : UserClaimDto<TKey>
        where TRoleClaimDto : RoleClaimDto<TKey>
    {
        private readonly IIdentityService<TUserDto, TRoleDto, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
            TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
            TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto, TApplication, TApplicationsDto> _identityService;
        private readonly IGenericControllerLocalizer<ApplicationController<TUserDto, TRoleDto, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
            TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
            TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto, TApplication, TApplicationsDto>> _localizer;

        public ApplicationController(IIdentityService<TUserDto, TRoleDto, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
                TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
                TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto, TApplication, TApplicationsDto> identityService,
            ILogger<ConfigurationController> logger,
            IGenericControllerLocalizer<ApplicationController<TUserDto, TRoleDto, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
                TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
                TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto, TApplication, TApplicationsDto>> localizer) : base(logger)
        {
            _identityService = identityService;
            _localizer = localizer;
        }

        [HttpGet]
        public async Task<IActionResult> Applications(int? page, string search)
        {
            ViewBag.Search = search;
            var apllications = await _identityService.GetApplicationsAsync(search, page ?? 1);
            return View(apllications);
        }
        [HttpGet]
        public async Task<IActionResult> Application(int id)
        {
            if (id == 0)
            {
                return View(new ApplicationDto());
            }

            var application = await _identityService.GetApplicationAsync(id);

            return View(application);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Application(ApplicationDto application)
        {
            if (!ModelState.IsValid)
            {
                return View(application);
            }

            int applicationId;

            if (application.Id == 0)
            {
                applicationId = await _identityService.CreateApplicationAsync(application);    
            }
            else
            {
                applicationId = await _identityService.UpdateApplicationAsync(application);              
            }

            SuccessNotification(string.Format(_localizer["SuccessCreateApplication"], application.Name), _localizer["SuccessTitle"]);

            return RedirectToAction(nameof(application), new { Id = applicationId });
        }

        [HttpGet]
        public async Task<IActionResult> ApplicationDelete(int id)
        {
            if (id == 0)
            {
                return View(new ApplicationDto());
            }
            var application = await _identityService.GetApplicationAsync(id);
            return View(application);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApplicationDelete(ApplicationDto application)
        {
            await _identityService.DeleteApplicationAsync(application);
            SuccessNotification(_localizer["SuccessDeleteApplication"], _localizer["SuccessTitle"]);
            return RedirectToAction(nameof(application));
        }
    }
}
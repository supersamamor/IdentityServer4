﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Application;
using Skoruba.IdentityServer4.Admin.BusinessLogic.Identity.Dtos.Identity;
using Skoruba.IdentityServer4.Admin.EntityFramework.Identity.Repositories.Interfaces;

namespace Skoruba.IdentityServer4.Admin.Api.Configuration.ApplicationParts
{
    public class GenericTypeControllerFeatureProvider<TUserDto, TRoleDto, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
        TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
        TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto, TApplication, TApplicationsDto> : IApplicationFeatureProvider<ControllerFeature>
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
        where TApplication : IApplication
        where TApplicationsDto : ApplicationsDto
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            var currentAssembly = typeof(GenericTypeControllerFeatureProvider<TUserDto, TRoleDto, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken,
                TUsersDto, TRolesDto, TUserRolesDto, TUserClaimsDto,
                TUserProviderDto, TUserProvidersDto, TUserChangePasswordDto, TRoleClaimsDto, TUserClaimDto, TRoleClaimDto, TApplication, TApplicationsDto>).Assembly;
            var controllerTypes = currentAssembly.GetExportedTypes()
                                                 .Where(t => typeof(ControllerBase).IsAssignableFrom(t) && t.IsGenericTypeDefinition)
                                                 .Select(t => t.GetTypeInfo());

            var type = this.GetType();
            var genericType = type.GetGenericTypeDefinition().GetTypeInfo();
            var parameters = genericType.GenericTypeParameters
                                        .Select((p, i) => new { p.Name, Index = i })
                                        .ToDictionary(a => a.Name, a => type.GenericTypeArguments[a.Index]);

            foreach (var controllerType in controllerTypes)
            {
                var typeArguments = controllerType.GenericTypeParameters
                                                  .Select(p => parameters[p.Name])
                                                  .ToArray();

                feature.Controllers.Add(controllerType.MakeGenericType(typeArguments).GetTypeInfo());
            }

        }
    }
}
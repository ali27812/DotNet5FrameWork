using Common;
using Data.Contracts;
using Data.Repositories;
using Entites;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;

namespace Services.Services
{
    public class AuthenticateService : IAuthenticateService, IScopedDependency
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ILogger<AuthenticateService> _log;
        public AuthenticateService(IRoleRepository roleRepository, ILogger<AuthenticateService> logger)
        {
            _roleRepository = roleRepository;
            _log = logger;
        }

        public void SetClaims(User user)
        {
            try
            {
                var role = _roleRepository.GetById(user.RoleId);
                if (role != null)
                {
                    //var identity = new ClaimsIdentity(new[]
                    //{
                    //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    //        new Claim(ClaimTypes.Surname, user.FullName ?? ""),
                    //        new Claim(ClaimTypes.Name, user.UserName ?? ""),
                    //        new Claim(ClaimTypes.Sid, role.Id.ToString() ?? ""),
                    //        new Claim(ClaimTypes.Role, role.Name ?? "")
                    //    }, "ApplicationCookie");

                    //var rolePermissionRepository = new RolePermissionTableRepository();
                    //var rolePermissions = rolePermissionRepository.Select().Where(t => t.RoleId == role.Id).ToList();
                    //if (rolePermissions.Any())
                    //    foreach (var permission in rolePermissions)
                    //    {
                    //        var permisionRepository = new PermissionTableRepository();
                    //        var rolePermission = permisionRepository
                    //            .Select().FirstOrDefault(t => t.Id == permission.PermissionId);
                    //        {
                    //            if (rolePermission != null)
                    //            {
                    //                var module = rolePermission.Permission.Split('_')[0];
                    //                identity.AddClaim(new Claim("RolePermission",
                    //                    rolePermission.Permission.ToLower()));
                    //                identity.AddClaim(new Claim("ModulePermission", module.ToLower()));
                    //            }
                    //        }
                    //    }

                    //var userPermissionRepository = new UsersPermissionTableRepository();
                    //var userPermissions = userPermissionRepository.Select().Where(t => t.UserId == result.Id).ToList();
                    //if (userPermissions.Any())
                    //    foreach (var permission in userPermissions)
                    //    {
                    //        var permisionRepository = new PermissionTableRepository();
                    //        var userPermission = permisionRepository
                    //            .Select().FirstOrDefault(t => t.Id == permission.PermissionId);
                    //        {
                    //            if (userPermission != null)
                    //            {
                    //                var module = userPermission.Permission.Split('_')[0];
                    //                identity.AddClaim(new Claim("UsersPermission",
                    //                    userPermission.Permission.ToLower()));
                    //                identity.AddClaim(new Claim("ModulePermission", module.ToLower()));
                    //            }
                    //        }
                    //    }
                    //var claimsPrincipal = new ClaimsPrincipal(identity);
                    //// Set current principal
                    //Thread.CurrentPrincipal = claimsPrincipal;
                    //var ctx = Request.GetOwinContext();
                    //var authManager = ctx.Authentication;
                    //authManager.SignIn(identity);
                    ////return Redirect(GetRedirectUrl(""));


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

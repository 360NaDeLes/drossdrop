using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DrossDrop.DTOs;
using DrossDrop.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DrossDrop.Attributes
{
    [AttributeUsage(AttributeTargets.Class |
                    AttributeTargets.Method)]
    public class RequiredRolesAttribute : TypeFilterAttribute
    {
        public RequiredRolesAttribute(string Roles) : base(typeof(RequiredRolesFilter))
        {
            Arguments = new object[] {Roles};
        }
    }

    public class RequiredRolesFilter : IAuthorizationFilter
    {
        private RoleHandler roleHandler = new RoleHandler();
        private UserHandler userHandler = new UserHandler();

        private List<int> roles;

        public RequiredRolesFilter(string Roles)
        {
            string[] roleNames = Roles.Split(',');

            roles = new List<int>();
            foreach (string roleName in roleNames)
            {
                Role role = roleHandler.SelectRoleByName(roleName.Trim());

                if (role != null)
                {
                    roles.Add(role.id);
                }

            }

        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string email = context.HttpContext.Session.GetString("_Email");
            if (string.IsNullOrEmpty(email))
            {
                context.Result = new RedirectToActionResult("Index", "Home", new { });
            }
            else
            {
                if (!CheckUserHasRoles(email))
                {
                    context.Result = new RedirectToActionResult("Index", "Home", new { });
                }
            }
        }

        private bool CheckUserHasRoles(string email)
        {
            int userRole = userHandler.SelectUserByEmail(email).roleId;

            if (!RoleInList(roles, userRole))
            {
                return false;
            }

            return true;
        }

        private bool RoleInList(List<int> roles, int role)
        {
            foreach (int listRole in roles)
            {
                if (listRole == role)
                {
                    return true;
                }
            }

            return false;
        }
    }
}


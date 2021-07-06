using System;
using System.Linq;
using System.Security.Claims;

namespace Dictionary
{
    public static class Extensions
    {
        public static bool IsAdmin(this ClaimsPrincipal userClaimsPrincipal)
        {
            return userClaimsPrincipal.IsInRole(Constants.AdminRoleName);
        }

        public static Guid UserId(this ClaimsPrincipal userClaimsPrincipal)
        {
            var userIdClaims = userClaimsPrincipal.Claims.FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier);
            if (userIdClaims == null)
            {
                return default;
            }

            return new Guid(userIdClaims.Value);
        }
    }
}

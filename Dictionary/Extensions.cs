using System.Security.Claims;

namespace Dictionary
{
    public static class Extensions
    {
        public static bool IsAdmin(this ClaimsPrincipal userClaimsPrincipal)
        {
           return userClaimsPrincipal.IsInRole(Constants.AdminRoleName);
        }
    }
}

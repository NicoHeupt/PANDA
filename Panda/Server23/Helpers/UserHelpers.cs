using System.Security.Claims;

namespace Server23.Helpers
{
    public static class UserHelpers
    {
        public static string GetUsername(ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name).Value;
        }
    }
}

using System;
using System.Security.Claims;

namespace iTechArt.SurveysSite.WebApp.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetId(this ClaimsPrincipal user)
        {
            var stringId = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!int.TryParse(stringId, out var id))
            {
                throw new InvalidCastException("User id is not valid");
            }

            return id;
        }
    }
}
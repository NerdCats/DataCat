namespace DataCat.Core.Utility
{
    using System.Linq;
    using System.Security.Claims;

    public static class IdentityExtensions
    {
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.Claims.First(x => x.Type == "sub").Value;
        }
    }
}

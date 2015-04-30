
using CMS.Core.Domain.Interfaces;
using CMS.Core.Domain.Services;

namespace CMS.Core.DependencyResolution
{
    public class DI
    {
        public static IAuthenticationService GetAuthenticationService()
        {
            return new AuthenticationService();
        }


    }
}

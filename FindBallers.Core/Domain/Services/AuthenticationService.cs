using System.DirectoryServices;
using System.Runtime.InteropServices;
using CMS.Core.Domain.Interfaces;
using CMS.Core.UI;

namespace CMS.Core.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        public bool PasswordMatches(string userName, string password)
        {
            var authenticated = false;
            var domainAndUsername = "NET_NT" + "\\" + userName;
            var entry = new DirectoryEntry(WebConfig.LDAPPath, domainAndUsername, password);
            try
            {
                var bindToNativeObjectToForceAuthentication = entry.NativeObject;
                authenticated = true;
            }
            catch (COMException)
            {
            }
            return authenticated;
        }
    }
}

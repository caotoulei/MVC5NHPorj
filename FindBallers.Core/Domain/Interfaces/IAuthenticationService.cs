using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Domain.Interfaces
{
    public interface IAuthenticationService
    {
        bool PasswordMatches(string userName, string password);
    }
}

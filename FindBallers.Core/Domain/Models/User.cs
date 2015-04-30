using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Domain.Models
{
    public class User
    {
        public virtual Guid Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string DisplayName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Contact { get; set; }
    }
}

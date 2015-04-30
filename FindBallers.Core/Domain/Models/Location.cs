using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Domain.Models
{
    public class Location
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
    }
}

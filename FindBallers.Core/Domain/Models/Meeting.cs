using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Domain.Models
{
    public class Meeting
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime DateTimeStart { get; set; }
        public virtual DateTime DateTimeEnd { get; set; }
        public virtual Location Location { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual IList<User> Users { get; set; }

        public Meeting()
        {
            Users = new List<User>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Domain
{
    public interface IRepository<T>
    {
        void Save(T record);
        void Update(T record);
        void Remove(T record);
        T GetById<T_Id>(T_Id id);
        IList<T> GetAll();
        IList<T> GetBy<T_Content>(T_Content content, string cName);
    }
}

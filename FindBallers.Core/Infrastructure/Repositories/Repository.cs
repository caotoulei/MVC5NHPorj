using System.Collections.Generic;
using CMS.Core.Domain;
using CMS.Core.Helpers;
using NHibernate;
using NHibernate.Criterion;

namespace CMS.Core.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T>
    {
        //private readonly string _connectionKey;
        //public Repository(string connectionKey)
        //{
        //    _connectionKey = connectionKey;
        //}


        public void Save(T record)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(record);
                transaction.Commit();
            }
        }

        public void Update(T record)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(record);
                transaction.Commit();
            }
        }

        public void Remove(T record)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(record);
                transaction.Commit();
            }
        }

        public T GetById<T_Id>(T_Id id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                return session.Get<T>(id);
        }

        public IList<T> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var records = session
                    .CreateCriteria(typeof(T))
                    .List<T>();
                return records;
            }
        }

        public IList<T> GetBy<T_Content>(T_Content content, string cName)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var records = session
                    .CreateCriteria(typeof(T))
                    .Add(Restrictions.Eq(cName, content))
                    .List<T>();
                return records;
            }
        }
    }
}

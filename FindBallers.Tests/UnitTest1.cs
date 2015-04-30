using System;
using System.Collections.Generic;
using CMS.Core.Domain;
using CMS.Core.Domain.Models;
using CMS.Core.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace CMS.Tests
{
    [TestClass]
    public class UnitTestForNHibernate
    {
        [TestMethod]
        public void Can_generate_schema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Court).Assembly);

            //new SchemaExport(cfg).Execute(false, true, false, false);
        }

        [TestMethod]
        public void Can_add_new_Court()
        {
            var court = new Court() { Name = "Toyota Center", Id = Guid.NewGuid(), Address = "Houston"};
            IRepository<Court> repository = new CourtRepository();
            repository.Save(court);
        }

        [TestMethod]
        public void Can_get_court()
        {
            IRepository<Court> repository = new CourtRepository();
            var courts = repository.GetAll();

            Assert.IsNotNull(courts);
        }

        [TestMethod]
        public void Can_add_new_Meeting()//many to many//save children?
        {
            var meeting = new Meeting() { Id = Guid.NewGuid(), DateTimeEnd = DateTime.Now, DateTimeStart = DateTime.Now, IsDeleted = false};
            meeting.Users = new List<User>();
            meeting.Users.Add(new User(){Id = Guid.NewGuid(), UserName = "user1", DisplayName = "User 1", Email = "lzhang@ccisd.net"});
            meeting.Location = new Location() { Id = Guid.NewGuid(), Name = "Toyota Center", Address = "Houston Downtown" };
            IRepository<Meeting> repository = new MeetingRepository();
            repository.Save(meeting);
        }


        [TestMethod]
        public void Can_Update_Meeting()//many to many//save children?
        {
            var meeting = new Meeting() { Id = new Guid("F4CDCD3B-CB6D-4ABD-8304-AE6B0439581B"), DateTimeEnd = DateTime.Now, DateTimeStart = DateTime.Now, IsDeleted = false };
            meeting.Users = new List<User>();
            meeting.Users.Add(new User() { Id = new Guid("2B70F460-20DE-4750-9A1F-28587C7DD7E5"), UserName = "user2", DisplayName = "User 2", Email = "leizhang1205@gmail.com" });
            meeting.Location = new Location() { Id = new Guid("FDB80B5E-9483-41F7-93E5-9A41755D36A3"), Name = "Toyota Center 2", Address = "Houston Downtown 2" };
            IRepository<Meeting> repository = new MeetingRepository();
            repository.Update(meeting);
        }

        //7C4128E8-D0DD-430E-8601-233F21586DF0
        [TestMethod]
        public void Can_get_Meeting()
        {
            IRepository<Meeting> repository = new Repository<Meeting>();
            var meeting = repository.GetById<Guid>(new Guid("F4CDCD3B-CB6D-4ABD-8304-AE6B0439581B"));

            Assert.IsNotNull(meeting.Users[0].UserName);
            Assert.AreEqual(meeting.Location.Name, "Toyota Center 2");
            //Assert.AreEqual(meeting.Users[0].UserName, "lzhang");
        }
    }
}

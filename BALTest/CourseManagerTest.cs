﻿using AutoMapper;
using BAL.IoC;
using BAL.Managers;
using DAL.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.DB;
using Model.DTO;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;

namespace BALTest
{
    [TestClass]
    public class CourseManagerTest
    {
        IMapper mapper;
        IUnitOfWork sUoW;

        [TestInitialize]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
            mapper = config.CreateMapper();

            var sNewsRepo = Substitute.For<IBaseRepository<Course>>();
            sUoW = Substitute.For<IUnitOfWork>();
        }

        [TestMethod]
        public void InsertTest()
        {
            var courseManager = new CourseManager(sUoW, mapper);
            courseManager.Insert(new CourseDTO() { Name = "aaa" });
            courseManager.Insert(new CourseDTO() { Name = "bbb" });
            sUoW.Received(2).Save();
            sUoW.ClearReceivedCalls();
        }

        [TestMethod]
        public void UpdateTest()
        {
            var courseManager = new CourseManager(sUoW, mapper);
            courseManager.Update(new CourseDTO() { Name = "aaa" });
            sUoW.Received(1).Save();
            sUoW.ClearReceivedCalls();
        }

        [TestMethod]
        public void DeleteTest()
        {
            var courseManager = new CourseManager(sUoW, mapper);
            courseManager.Delete(new CourseDTO() { Name = "aaa" });
            sUoW.Received(1).Save();
            sUoW.ClearReceivedCalls();
        }

        [TestMethod]
        public void GetByIdTest()
        {
            sUoW.CourseRepo.GetById(1).Returns(new Course() { Name = "aaa", UserId = "aaa" });
            var courseManager = new CourseManager(sUoW, mapper);
            Assert.AreEqual("aaa", courseManager.GetById(1).UserId);
        }

        [TestMethod]
        public void GetTest()
        {
            var courseManager = new CourseManager(sUoW, mapper);
            sUoW.CourseRepo.Get(c => c.Name == "aaa").Returns(new List<Course>() { new Course() { Name = "aaa", UserId = "aaa" }, new Course() { Name = "aaa", UserId = "bbb" } });
            var a = sUoW.CourseRepo.Get(c => c.Name == "aaa");
            Assert.AreEqual("aaa", courseManager.Get(c => c.Name == "aaa").FirstOrDefault().Name);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var courseManager = new CourseManager(sUoW, mapper);
            sUoW.CourseRepo.GetAll().Returns(new List<Course>() { new Course() { Name = "aaa" }, new Course() { Name = "bbb" } });
            Assert.AreEqual("aaa", courseManager.GetAll().FirstOrDefault().Name);
        }

        [TestMethod]
        public void UpdateCourseOwnerTest()
        {
            sUoW.CourseRepo.GetById(1).Returns(new Course() { Name = "aaa", UserId = "aaa" });
            var courseManager = new CourseManager(sUoW, mapper);
            courseManager.UpdateCourseOwner(1, "bbb");
            Assert.AreEqual("bbb", courseManager.GetById(1).UserId);
        }


        [TestMethod]
        public void ToggleCourseStatusTest()
        {
            var courseManager = new CourseManager(sUoW, mapper);
            sUoW.CourseRepo.GetById(1).Returns(new Course() { Name = "aaa", UserId = "aaa", IsActive = true });
            courseManager.ToggleCourseStatus(1);
            Assert.AreEqual(false, courseManager.GetById(1).IsActive);
        }
    }
}

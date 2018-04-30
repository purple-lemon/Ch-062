﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebApp.Models;
using WebApp.ViewModels;
using Model.DB;
using Model.DTO;
using Microsoft.AspNetCore.Authorization;
using DAL.Interface;
using BAL.Interfaces;
using WebApp.ViewModels.CoursesViewModels;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers
{
    public class ExerciseManagementController : Controller
    {
        private readonly IExerciseManager exerciseManager;
        private readonly ICourseManager courseManager;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;
        private readonly ITestCaseManager testCaseManager;

        public ExerciseManagementController(IExerciseManager exerciseManager, ICourseManager courseManager,
                                            UserManager<User> userManager, IMapper mapper, ITestCaseManager testCaseManager)
        {
            this.exerciseManager = exerciseManager;
            this.courseManager = courseManager;
            this.userManager = userManager;
            this.mapper = mapper;
            this.testCaseManager = testCaseManager;
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult Index()
        {
            var exerciseList = exerciseManager.GetAll();
            return View(exerciseList);
        }


        [Authorize(Roles = "Teacher")]
        public IActionResult Create()
        {
            var courseList = courseManager.Get(x => x.IsActive).ToList();
            return View(new CreateExerciseViewModel()
            {
                CourseList = courseList
            });
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Create(CreateExerciseViewModel model)
        {
            var currentTeacher = userManager.GetUserAsync(HttpContext.User).Result.Id;

            if (ModelState.IsValid)
            {
                var course = courseManager.GetById(model.CourseId);
                ExerciseDTO task = new ExerciseDTO
                {
                    CourseId = model.CourseId,
                    Course = course.Name,
                    TaskName = model.TaskName,
                    TaskTextField = model.TaskTextField,
                    TaskBaseCodeField = model.TaskBaseCodeField,
                    TeacherId = currentTeacher,
                    CreateDateTime = DateTime.Now,
                    UpdateDateTime = DateTime.Now
                };
                exerciseManager.Insert(task);
            }
            return RedirectToAction("Index", "ExerciseManagement");
        }


        public IActionResult TaskView(int id)
        {
            var task = mapper.Map<ExerciseDTO>(exerciseManager.GetById(id));
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }


        [Authorize(Roles = "Teacher")]
        public IActionResult Update(int id)
        {
            var courseList = courseManager.Get(g => g.IsActive).ToList();
            var task = exerciseManager.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(new UpdateExerciseViewModel()
            {
                Id = id,
                CourseList = courseList,
                TaskName = task.TaskName,
                TaskTextField = task.TaskTextField,
                TaskBaseCodeField = task.TaskBaseCodeField
            });

        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult Update(UpdateExerciseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var course = courseManager.GetById(model.CourseId);
                var task = new ExerciseDTO()
                {
                    Id = model.Id,
                    TaskName = model.TaskName,
                    TaskTextField = model.TaskTextField,
                    TaskBaseCodeField = model.TaskBaseCodeField,
                    CourseId = model.CourseId,
                    Course = course.Name,
                    UpdateDateTime = DateTime.Now
                };
                exerciseManager.Update(task);
            }
            return RedirectToAction("Index", "ExerciseManagement");
        }



        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult DeleteOrRecover(int id)
        {
            var task = exerciseManager.GetById(id);
            if (task != null)
            {
                task.IsDeleted = !task.IsDeleted;
                exerciseManager.Update(task);
            }
            return RedirectToAction("Index", "ExerciseManagement");
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult Testcases(int id)
        {
            var testcases = testCaseManager.GetByExerciseId(id);
            return View(testcases);
        }

        [HttpGet]
        [Authorize(Roles = "Teacher")]
        public IActionResult EditTestCase(int id)
        {
            var testcase = testCaseManager.GetById(id);
            return View(testcase);
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult EditTestCase(TestCaseDTO testCaseDTO)
        {
            if (ModelState.IsValid)
            {
                testCaseManager.Update(testCaseDTO);
            }
            return RedirectToAction("Index", "ExerciseManagement");
        }

        [Authorize(Roles = "Teacher")]
        public IActionResult CreateTestCase()
        {
            return View(new CreateTestCase() { ExerciseList = exerciseManager.GetAll() });
        }

        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public IActionResult CreateTestCase(CreateTestCase model)
        {
            model.TestCaseDTO.UserDTOId = userManager.GetUserId(HttpContext.User);
            if (ModelState.IsValid)
            {
                var test = new TestCaseDTO()
                {
                    ExerciseDTOId = model.TestCaseDTO.ExerciseDTOId,
                    UserDTOId = model.TestCaseDTO.UserDTOId,
                    InputData = model.TestCaseDTO.InputData,
                    OutputData = model.TestCaseDTO.OutputData
                };
                testCaseManager.Insert(test);
            }
            return RedirectToAction("Index", "ExerciseManagement");
        }
    }
}
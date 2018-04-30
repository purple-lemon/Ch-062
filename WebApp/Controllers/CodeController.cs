﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BAL.Interfaces;
using BAL.Managers;
using DAL.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Model.DB;
using Model.DB.Code;
using Model.DTO.CodeDTO;

namespace WebApp.Controllers
{
    public class CodeController : Controller
    {
        private CodeManager codeManager;

        public CodeController(CodeManager codeManager)
        {
            this.codeManager = codeManager;
        }
        public IActionResult Index(UserCodeDTO model)
        {
            if (!ModelState.IsValid)
            {
                return Redirect("Home/Index");
            }
            return View(codeManager.BuildCodeModel(model));
        }

        [HttpPost]
        public string GetCode(UserCodeDTO model)
        {
            return codeManager.ExecuteCode(model); 
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ViewModels
{
    public class GetExerciseViewModel
    {
        public int Id { get; set; }

        public string Course { get; set; }

        public string TaskName { get; set; }

        public string TaskTextField { get; set; }

        public string TaskBaseCodeField { get; set; }

        public bool IsDeleted { get; set; }

    }
}
﻿using System;

namespace Model.DTO
{
    public class ExerciseDTO
    {
        public int Id { get; set; }

        public string TeacherId { get; set; }

        public string TaskName { get; set; }

        public string TaskTextField { get; set; }

        public string TaskBaseCodeField { get; set; }

        public string TestCasesCode { get; set; }

        public int CourseId { get; set; }
        
        public string Course { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }

        public double Rating { get; set; }
    }
}

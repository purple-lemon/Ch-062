﻿using System;

namespace Model.DB
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
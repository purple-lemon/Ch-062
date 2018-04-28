﻿using System.Collections.Generic;
using Model.DTO.CodeDTO;

namespace Model.DB.Code
{
    public class UserCode
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ExerciseId { get; set; }
        public string CodeText { get; set; }

        public virtual CodeError CodeError { get; set; }
        public virtual CodeResult CodeResult { get; set; }
        public virtual CodeHistory CodeHistory { get; set; }

        public virtual User User { get; set; }
        public virtual Exercise Exercise { get; set; }


    }
}

﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.DB;
using Model.DB.Code;

namespace Model.DTO.CodeDTO
{
    public class UserCodeDTO
    {
        public int Id { get; set; }
        public string CodeText { get; set; }
        
        public ICollection<CodeHistoryDTO> CodeHistories { get; set; }


        [Required]
        public string UserId { get; set; }
        public UserDTO User { get; set; }

        [Required]
        public int ExerciseId { get; set; }
        public ExerciseDTO Exercise { get; set; }
    }
}

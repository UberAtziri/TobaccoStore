﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TobaccoStore.DTO
{
    public class TobaccoDto
    {
        [Required]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool isOnStock { get; set; }
    }
}

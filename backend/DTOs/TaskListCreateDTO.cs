using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class TaskListCreateDTO
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}

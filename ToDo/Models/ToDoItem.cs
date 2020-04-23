using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Task Name")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "To Do Status")]
        public bool ToDoStatus { get; set; }
        public int ToDoStatusId  { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
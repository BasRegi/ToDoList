using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.DTOs
{
    public class TaskListReadFullDTO : TaskListReadDTO
    {
        public IEnumerable<ToDoItem> ToDoItems;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Data
{
    public interface IToDoListRepo
    {
        IEnumerable<ToDoItem> GetAll();
        ToDoItem GetItemById(int Id);
    }
}

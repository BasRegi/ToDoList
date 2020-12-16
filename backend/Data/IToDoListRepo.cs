using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Data
{
    public interface IToDoListRepo
    {
        bool SaveChanges();

        IEnumerable<ToDoItem> GetAll();
        ToDoItem GetItemById(int Id);
        void CreateItem(ToDoItem item);
        void UpdateItem(ToDoItem item);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Data.Contracts
{
    public interface ITaskListRepo
    {
        IEnumerable<TaskList> GetAll();
        TaskList GetListById(int Id);
        void CreateList(TaskList list);
        void UpdateList(TaskList list);
        void DeleteList(TaskList list);
    }
}

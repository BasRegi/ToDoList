using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data.Contracts
{
    public interface IRepository
    {
        IToDoItemsRepo ToDoItemsRepo { get; }
        ITaskListRepo TaskListRepo { get; }
        void Save();
    }
}

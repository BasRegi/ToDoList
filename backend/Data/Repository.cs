using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Contracts;

namespace backend.Data
{
    public class Repository : IRepository
    {
        private DataContext _context;

        private IToDoItemsRepo _toDoItems;

        private ITaskListRepo _taskLists;

        public Repository(DataContext context)
        {
            _context = context;
        }

        public IToDoItemsRepo ToDoItemsRepo
        {
            get
            {
                if (_toDoItems == null)
                {
                    _toDoItems = new ToDoItemsRepo(_context);
                }

                return _toDoItems;
            }
        }

        public ITaskListRepo TaskListRepo
        {
            get
            {
                if (_taskLists == null)
                {
                    _taskLists = new TaskListRepo(_context);
                }

                return _taskLists;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Contracts;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class TaskListRepo : ITaskListRepo
    {
        private DataContext _context;

        public TaskListRepo(DataContext context)
        {
            _context = context;
        }

        public void CreateList(TaskList list)
        {
            if(list == null)
            {
                throw new ArgumentNullException();
            }

            _context.TaskList.Add(list);
        }

        public void DeleteList(TaskList list)
        {
            if(list == null)
            {
                throw new ArgumentNullException();
            }

            _context.TaskList.Remove(list);
        }

        public IEnumerable<TaskList> GetAll()
        {
            return _context.TaskList.Include(x => x.ToDoItems).ToList();
        }

        public TaskList GetListById(int Id)
        {
            return _context.TaskList.Include(y => y.ToDoItems).FirstOrDefault(x => x.Id == Id);
        }

        public void UpdateList(TaskList list)
        {
            //Nothing to do
        }
    }
}

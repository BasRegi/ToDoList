using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class SQLToDoListRepo : IToDoListRepo
    {
        private readonly ToDoListContext _context;
        public SQLToDoListRepo(ToDoListContext context)
        {
            _context = context;
        }

        public void CreateItem(ToDoItem item)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _context.ToDoItems.Add(item);
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            return _context.ToDoItems.ToList();
        }

        public ToDoItem GetItemById(int Id)
        {
            return _context.ToDoItems.FirstOrDefault(x => x.Id == Id);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }
    }
}

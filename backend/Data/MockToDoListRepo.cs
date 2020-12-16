using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Data
{
    /**
     * Class to mock data to be passed to API
     */
    public class MockToDoListRepo : IToDoListRepo
    {
        public IEnumerable<ToDoItem> GetAll()
        {
            var Items = new List<ToDoItem>
            {
                new ToDoItem
                {
                    Id = 1,
                    Title = "Mock Item 1",
                    Description = "Mock Description 1",
                    CreatedOn = DateTime.Today,
                    Deadline = DateTime.Today.AddDays(10.0),
                    isComplete = false
                },
                new ToDoItem
                {
                    Id = 2,
                    Title = "Mock Item 2",
                    Description = "Mock Description 2",
                    CreatedOn = DateTime.Today,
                    Deadline = DateTime.Today.AddDays(5.0),
                    isComplete = false
                },
                new ToDoItem
                {
                    Id = 3,
                    Title = "Mock Item 3",
                    Description = "Mock Description 3",
                    CreatedOn = DateTime.Today,
                    Deadline = DateTime.Today.AddDays(3.0),
                    isComplete = false
                },
            };

            return Items;
        }

        public ToDoItem GetItemById(int id)
        {
            return new ToDoItem
            {
                Id = id,
                Title = "Mock Item",
                Description = "Mock Description",
                CreatedOn = DateTime.Today,
                Deadline = DateTime.Today.AddDays(10.0),
                isComplete = false
            };
        }
    }
}

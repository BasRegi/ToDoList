using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/todoitems")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoListRepo _repository;

        public ToDoItemsController(IToDoListRepo repository)
        {
            _repository = repository;
        }

        //GET api/toditems
        [HttpGet]
        public ActionResult<IEnumerable<ToDoItem>> GetAll()
        {
            var items = _repository.GetAll();

            return Ok(items);
        }

        //GET api/todoitems/{id}
        [HttpGet("{id}")]
        public ActionResult<ToDoItem> GetItemById(int id)
        {
            var item = _repository.GetItemById(id);

            return Ok(item);
        }


    }
}

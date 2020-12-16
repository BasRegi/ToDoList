using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/todoitems")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoListRepo _repository;
        private readonly IMapper _mapper;

        public ToDoItemsController(IToDoListRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/toditems
        [HttpGet]
        public ActionResult<IEnumerable<ToDoItem>> GetAll()
        {
            var items = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<ToDoItemReadDTO>>(items));
        }

        //GET api/todoitems/{id}
        [HttpGet("{id}", Name = "GetItemById")]
        public ActionResult<ToDoItemReadDTO> GetItemById(int id)
        {
            var item = _repository.GetItemById(id);

            if(item != null)
            {
                return Ok(_mapper.Map<ToDoItemReadDTO>(item));
            }

            return NotFound();
        }

        //POST api/todoitems
        [HttpPost]
        public ActionResult<ToDoItemReadDTO> CreateItem(ToDoItemCreateDTO itemCreateDTO)
        {
            var item = _mapper.Map<ToDoItem>(itemCreateDTO);
            item.CreatedOn = DateTime.Now;
            
            _repository.CreateItem(item);
            _repository.SaveChanges();

            var itemReadDTO =_mapper.Map<ToDoItemReadDTO>(item);

            return CreatedAtRoute(nameof(GetItemById), new { itemReadDTO.Id }, itemReadDTO);
        }

        //PUT api/todoitems/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, ToDoItemUpdateDTO itemUpdateDTO)
        {
            var item = _repository.GetItemById(id);

            if(item == null)
            {
                return NotFound();
            }

            _mapper.Map(itemUpdateDTO, item);
            _repository.UpdateItem(item);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}

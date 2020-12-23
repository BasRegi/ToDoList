using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data;
using backend.Data.Contracts;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ToDoItemsController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/items
        [HttpGet]
        public ActionResult<IEnumerable<ToDoItem>> GetAll()
        {
            var items = _repository.ToDoItemsRepo.GetAll();

            return Ok(_mapper.Map<IEnumerable<ToDoItemReadDTO>>(items));
        }

        //GET api/items/{id}
        [HttpGet("{id}", Name = "GetItemById")]
        public ActionResult<ToDoItemReadDTO> GetItemById(int id)
        {
            var item = _repository.ToDoItemsRepo.GetItemById(id);

            if(item != null)
            {
                return Ok(_mapper.Map<ToDoItemReadDTO>(item));
            }

            return NotFound();
        }

        //POST api/items
        [HttpPost]
        public ActionResult<ToDoItemReadDTO> CreateItem(ToDoItemCreateDTO itemCreateDTO)
        {
            var item = _mapper.Map<ToDoItem>(itemCreateDTO);
            item.CreatedOn = DateTime.Now;
            
            _repository.ToDoItemsRepo.CreateItem(item);
            _repository.Save();

            var itemReadDTO =_mapper.Map<ToDoItemReadDTO>(item);

            return CreatedAtRoute(nameof(GetItemById), new { itemReadDTO.Id }, itemReadDTO);
        }

        //PUT api/items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(int id, ToDoItemUpdateDTO itemUpdateDTO)
        {
            var item = _repository.ToDoItemsRepo.GetItemById(id);

            if(item == null)
            {
                return NotFound();
            }

            _mapper.Map(itemUpdateDTO, item);
            _repository.ToDoItemsRepo.UpdateItem(item);
            _repository.Save();

            return NoContent();
        }

        //PATCH api/items/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateItem(int id, JsonPatchDocument<ToDoItemUpdateDTO> patchDoc)
        {
            var item = _repository.ToDoItemsRepo.GetItemById(id);

            if (item == null)
            {
                return NotFound();
            }

            var itemUpdateDTO = _mapper.Map<ToDoItemUpdateDTO>(item);
            
            patchDoc.ApplyTo(itemUpdateDTO, ModelState);
            if(!TryValidateModel(itemUpdateDTO))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(itemUpdateDTO, item);
            _repository.ToDoItemsRepo.UpdateItem(item);
            _repository.Save();

            return NoContent();
        }

        //DELETE api/items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(int id)
        {
            var item = _repository.ToDoItemsRepo.GetItemById(id);
            if (item == null)
            {
                return NotFound();
            }

            _repository.ToDoItemsRepo.DeleteItem(item);
            _repository.Save();

            return NoContent();
        }

    }
}

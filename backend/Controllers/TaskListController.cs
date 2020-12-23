using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Data.Contracts;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/lists")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public TaskListController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET /api/lists
        [HttpGet]
        public ActionResult<IEnumerable<TaskList>> GetAll()
        {
            var lists = _repository.TaskListRepo.GetAll().ToList();
            var listsDTO = _mapper.Map<IEnumerable<TaskListReadDTO>>(lists);
            return Ok(listsDTO);
        }

        //GET /api/lists/full
        [HttpGet("full")]
        public ActionResult<IEnumerable<TaskList>> GetAllFull()
        {
            var lists = _repository.TaskListRepo.GetAll().ToList();
            var listsDTO = _mapper.Map<IEnumerable<TaskListReadFullDTO>>(lists);
            return Ok(listsDTO);
        }

        //GET /api/lists/{id}
        [HttpGet("{id}", Name = "GetListById")]
        public ActionResult<TaskListReadDTO> GetListById(int id)
        {
            var list = _repository.TaskListRepo.GetListById(id);
            var listDTO = _mapper.Map<TaskListReadDTO>(list);
            return Ok(listDTO);
        }

        //GET /api/lists/full/{id}
        [HttpGet("full/{id}", Name = "GetListByIdFull")]
        public ActionResult<TaskListReadDTO> GetListByIdFull(int id)
        {
            var list = _repository.TaskListRepo.GetListById(id);
            var listDTO = _mapper.Map<TaskListReadFullDTO>(list);
            return Ok(listDTO);
        }

        //POST /api/lists
        [HttpPost]
        public ActionResult<TaskListCreateDTO> CreateList(TaskListCreateDTO listDTO)
        {
            var list = _mapper.Map<TaskList>(listDTO);

            _repository.TaskListRepo.CreateList(list);
            _repository.Save();

            var listReadDTO = _mapper.Map<TaskListReadDTO>(list);

            return CreatedAtRoute(nameof(GetListById), new { listReadDTO.Id }, listReadDTO);
        }

        //PUT /api/lists/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateList(TaskListReadDTO listDTO)
        {
            var list = _repository.TaskListRepo.GetListById(listDTO.Id);

            if(list == null)
            {
                return NotFound();
            }

            _mapper.Map(listDTO, list);
            _repository.TaskListRepo.UpdateList(list);
            _repository.Save();

            return NoContent();
        }

        //DELETE /api/lists/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteList(int Id)
        {
            var list = _repository.TaskListRepo.GetListById(Id);

            if(list == null)
            {
                return NotFound();
            }

            _repository.TaskListRepo.DeleteList(list);
            _repository.Save();

            return NoContent();
        }
    }
}

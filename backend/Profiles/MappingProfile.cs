using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoItem, ToDoItemReadDTO>();
            CreateMap<ToDoItemCreateDTO, ToDoItem>();
            CreateMap<ToDoItemUpdateDTO, ToDoItem>();
            CreateMap<ToDoItem, ToDoItemUpdateDTO>();
        }
    }
}

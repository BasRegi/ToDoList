using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend.Profiles
{
    public class ToDoItemsProfile : Profile
    {
        public ToDoItemsProfile()
        {
            CreateMap<ToDoItem, ToDoItemReadDTO>();
            CreateMap<ToDoItemCreateDTO, ToDoItem>();
        }
    }
}

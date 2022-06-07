using AutoMapper;
using books_library_api_net.DTOs;
using books_library_api_net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace books_library_api_net.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            AllowNullCollections = true;
            CreateMap<BookCreateDto, Book>();
        }
    }
}

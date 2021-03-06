﻿using AutoMapper;
using BookStoreAPI.Data;
using BookStoreAPI.DTOs;

namespace BookStoreAPI.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}

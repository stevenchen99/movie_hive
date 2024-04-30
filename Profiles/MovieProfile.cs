using AutoMapper;
using MovieHive.DTOs;
using MovieHive.Models;

namespace MovieHive.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDTO>();
            CreateMap<Movie, MovieLiteDTO>();
            CreateMap<MovieUpdateDTO, Movie>();
        }
    }
}

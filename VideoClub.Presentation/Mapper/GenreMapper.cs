using AutoMapper;
using VideoClub.Domain.Entities;

public class GenreMapper : Profile
{
	public GenreMapper()
	{
		CreateMap<Genre, GenreDTO>();
	}
}
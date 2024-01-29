using AutoMapper;
using VideoClub.Domain.Entities;

public class MovieMapper : Profile
{
	public MovieMapper()
	{
		CreateMap<Movie, MovieDTO>();
	}
}
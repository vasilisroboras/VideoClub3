using CleanArchitecture.Domain.Common;

namespace VideoClub.Domain.Entities
{
	public class Genre : IEntity
	{
		public int Id { get; }
		public string Name { get; }

		public Genre()
        {
        }

		internal Genre(int id, string name)
		{
			Id = id;
			Name = name;
		}
	}
}
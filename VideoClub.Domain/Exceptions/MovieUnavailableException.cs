using System;
using System.Runtime.Serialization;

namespace VideoClub.Domain.Exceptions
{
	public class MovieUnavailableException : Exception
	{
		public MovieUnavailableException()
		{
		}

		public MovieUnavailableException(string message) : base(message)
		{
		}

		public MovieUnavailableException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected MovieUnavailableException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}

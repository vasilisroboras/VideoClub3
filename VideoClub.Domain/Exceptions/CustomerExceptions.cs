using System;
using System.Runtime.Serialization;

namespace VideoClub.Domain.Exceptions
{
	public class InvalidRentalException : Exception
	{
		public InvalidRentalException()
		{
		}

		public InvalidRentalException(string message) : base(message)
		{
		}

		public InvalidRentalException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InvalidRentalException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}

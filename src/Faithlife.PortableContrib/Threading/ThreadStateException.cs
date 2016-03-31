
namespace System.Threading
{
	public class ThreadStateException : Exception
	{
		public ThreadStateException()
			: base("ThreadStateException")
		{
		}

		public ThreadStateException(string message)
			: base(message)
		{
		}

		public ThreadStateException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}

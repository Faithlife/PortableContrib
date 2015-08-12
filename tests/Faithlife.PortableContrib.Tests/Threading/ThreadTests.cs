using System.Threading;
using Xunit;

namespace Faithlife.PortableContrib.Tests.Threading
{
	public class ThreadTests
	{
		[Fact]
		public void TestStart()
		{
			bool threadRan = false;
			ThreadStart start = () => threadRan = true;

			var thread = new Thread(start);
			thread.Start();
			thread.Join();

			Assert.True(threadRan);
		}
	}
}

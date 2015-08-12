using System.Globalization;
using Xunit;

namespace Faithlife.PortableContrib.Tests.Globalization
{
	public class SortKeyTests
	{
		[Fact]
		public void TestDefaultOptions()
		{
			var compareInfo = CultureInfo.InvariantCulture.CompareInfo;
	
			var sortKey1 = compareInfo.GetSortKey("test");
			var sortKey2 = compareInfo.GetSortKey("test", CompareOptions.None);

			Assert.Equal(sortKey1.OriginalString, sortKey2.OriginalString);
			Assert.Equal(sortKey1.KeyData, sortKey2.KeyData);
		}

		[Fact]
		public void TestDifferentCase()
		{
			var compareInfo = CultureInfo.InvariantCulture.CompareInfo;

			var sortKey1 = compareInfo.GetSortKey("test");
			var sortKey2 = compareInfo.GetSortKey("TEST");

			Assert.NotEqual(sortKey1.OriginalString, sortKey2.OriginalString);
			Assert.NotEqual(sortKey1.KeyData, sortKey2.KeyData);
		}

		[Fact]
		public void TestCaseInsensitive()
		{
			var compareInfo = CultureInfo.InvariantCulture.CompareInfo;

			var sortKey1 = compareInfo.GetSortKey("test", CompareOptions.IgnoreCase);
			var sortKey2 = compareInfo.GetSortKey("TEST", CompareOptions.IgnoreCase);

			Assert.NotEqual(sortKey1.OriginalString, sortKey2.OriginalString);
			Assert.Equal(sortKey1.KeyData, sortKey2.KeyData);
		}
	}
}

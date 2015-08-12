namespace System.Globalization
{
	/// <summary>
	/// Portable extension methods for CompareInfo.
	/// </summary>
	public static class CompareInfoPortableExtensions
	{
		/// <summary>
		/// Gets the sort key for the specified string.
		/// </summary>
		/// <param name="compareInfo"></param>
		/// <param name="source"></param>
		/// <param name="options"></param>
		/// <returns></returns>
		public static SortKey GetSortKey(this CompareInfo compareInfo, string source, CompareOptions options = CompareOptions.None)
		{
#if PORTABLE
			throw new PlatformNotSupportedException();
#else
			return compareInfo.GetSortKey(source, options);
#endif
		}
	}
}

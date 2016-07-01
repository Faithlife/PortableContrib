using System.Text;

namespace System
{
	public static class StringPortableExtensions
	{
		public static string Normalize(this string value)
		{
#if PORTABLE
			throw new PlatformNotSupportedException();
#else
			return value.Normalize();
#endif
		}

		public static string Normalize(this string value, NormalizationForm normalizationForm)
		{
#if PORTABLE
			throw new PlatformNotSupportedException();
#else
			return value.Normalize(normalizationForm);
#endif
		}
	}
}

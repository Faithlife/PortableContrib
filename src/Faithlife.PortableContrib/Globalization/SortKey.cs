using System;

namespace System.Globalization
{
	/// <summary>
	/// Represents the result of mapping a string to its sort key.
	/// </summary>
	public class SortKey
	{
		internal SortKey()
		{
		}

		/// <summary>
		/// Gets the byte array representing the current SortKey object.
		/// </summary>
		public virtual byte[] KeyData
		{
			get { throw new PlatformNotSupportedException(); }
		}

		/// <summary>
		/// Gets the original string used to create the current SortKey object.
		/// </summary>
		public virtual string OriginalString
		{
			get { throw new PlatformNotSupportedException(); }
		}

		public static int Compare(SortKey sortkey1, SortKey sortkey2)
		{
			throw new PlatformNotSupportedException();
		}
	}
}

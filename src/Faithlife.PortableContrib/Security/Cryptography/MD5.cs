using System.Adaptation;
using System.Security.Cryptography.Adaptation;

namespace System.Security.Cryptography
{
    /// <summary>
    /// Computes the MD5 hash for the input data.
    /// </summary>
    public class MD5 : HashAlgorithm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MD5" /> class.
        /// </summary>
        public MD5()
            : base(PlatformAdapter.Resolve<ICryptographyFactory>().CreateMd5())
        {
        }

        /// <summary>
        /// Creates an instance of the MD5 hash algorithm.
        /// </summary>
        public static MD5 Create()
        {
            return new MD5();
        }
    }
}
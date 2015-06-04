// -----------------------------------------------------------------------
// Copyright (c) David Kean. All rights reserved.
// -----------------------------------------------------------------------
using System;
using System.Adaptation;
using System.Security.Cryptography.Adaptation;

namespace System.Security.Cryptography
{
    /// <summary>
    ///     Computes the SHA-1 hash for the input data using the managed library.
    /// </summary>
    public class SHA1 : HashAlgorithm
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SHA1"/> class.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     The Federal Information Processing Standards (FIPS) security setting is enabled. This implementation is not part of the Windows Platform FIPS-validated cryptographic algorithms.
        /// </exception>
        public SHA1()
            : base(PlatformAdapter.Resolve<ICryptographyFactory>().CreateSha1Managed())
        {
        }

        /// <summary>
        /// Creates an instance of the SHA1 hash algorithm.
        /// </summary>
        public static SHA1 Create()
        {
            return new SHA1();
        }
    }
}

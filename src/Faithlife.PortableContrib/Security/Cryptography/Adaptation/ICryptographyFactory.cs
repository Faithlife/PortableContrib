// -----------------------------------------------------------------------
// Copyright (c) David Kean. All rights reserved.
// -----------------------------------------------------------------------
using System;
using System.IO;

namespace System.Security.Cryptography.Adaptation
{
    internal interface ICryptographyFactory
    {
        IHashAlgorithm CreateSha256Managed();

        IHashAlgorithm CreateSha1Managed();

        IHashAlgorithm CreateMd5();

        IKeyedHashAlgorithm CreateHMacSha256();

        IKeyedHashAlgorithm CreateHMacSha1();

        ISymmetricAlgorithm CreateAesManaged();

        IDeriveBytes CreateRfc2898DeriveBytes(string password, byte[] salt, int iterations);
    }
}

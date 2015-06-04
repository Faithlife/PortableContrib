// -----------------------------------------------------------------------
// Copyright (c) David Kean. All rights reserved.
// -----------------------------------------------------------------------
using System;

namespace System.Adaptation
{
    // Enables types within PclContrib to use platform-specific features in a platform-agnostic way
    internal static class PlatformAdapter
    {
        public static T Resolve<T>()
        {
            throw new PlatformNotSupportedException();
        }
    }
}

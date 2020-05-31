using System;

namespace Evan.Wpf
{
    public sealed class DependencyHelperException : Exception
    {
        internal DependencyHelperException(string message) : base(message)
        {
        }
    }
}

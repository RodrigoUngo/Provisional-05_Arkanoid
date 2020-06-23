using System;

namespace Arkanoid
{
    public class EmptyFieldException : Exception
    {
        public EmptyFieldException(string message) : base(message)
        {
        }
    }
}
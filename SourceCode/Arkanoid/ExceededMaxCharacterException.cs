using System;

namespace Arkanoid
{
    public class ExceededMaxCharacterException : Exception
    {
        public ExceededMaxCharacterException(string message) : base(message)
        {
        }
    }
}
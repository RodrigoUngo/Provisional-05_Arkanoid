using System;

namespace Arkanoid
{
    public class GameWinException : Exception
    {
        public GameWinException(string message) : base(message)
        {
        }
    }
}
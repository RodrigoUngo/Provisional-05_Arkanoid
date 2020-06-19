using System;

namespace Arkanoid
{
    public class GameOverException : Exception
    {
        public GameOverException(string message) : base(message)
        {
        }
    }
}
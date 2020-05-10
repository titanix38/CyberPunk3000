using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Factory
{
    public class CharacterException : Exception
    {
        public CharacterException() { }

        public CharacterException(string message) : base(message) { }

        public CharacterException(string message, Exception inner) : base(message, inner) { }

    }
}

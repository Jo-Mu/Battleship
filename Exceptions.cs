using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship
{
    class OutOfBoundsException : System.SystemException
    {
        public OutOfBoundsException()
        { }

        public OutOfBoundsException(string message) : base(message)
        { }
    }
}

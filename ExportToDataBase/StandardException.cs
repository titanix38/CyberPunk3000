﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ExportToDataBase
{
    [Serializable]
    internal class StandardException : Exception
    {
        public StandardException()
        {
        }

        public StandardException(string message) : base(message)
        {
        }

        public StandardException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StandardException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

using System;
using System.Runtime.Serialization;

namespace EasyModbus
{
    internal class Exceptions
    {
        [Serializable]
        internal class ConnectionException : Exception
        {
            public ConnectionException()
            {
            }

            public ConnectionException(string message) : base(message)
            {
            }

            public ConnectionException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected ConnectionException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        [Serializable]
        internal class SerialPortNotOpenedException : Exception
        {
            public SerialPortNotOpenedException()
            {
            }

            public SerialPortNotOpenedException(string message) : base(message)
            {
            }

            public SerialPortNotOpenedException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected SerialPortNotOpenedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        [Serializable]
        internal class FunctionCodeNotSupportedException : Exception
        {
            public FunctionCodeNotSupportedException()
            {
            }

            public FunctionCodeNotSupportedException(string message) : base(message)
            {
            }

            public FunctionCodeNotSupportedException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected FunctionCodeNotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        [Serializable]
        internal class StartingAddressInvalidException : Exception
        {
            public StartingAddressInvalidException()
            {
            }

            public StartingAddressInvalidException(string message) : base(message)
            {
            }

            public StartingAddressInvalidException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected StartingAddressInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        [Serializable]
        internal class QuantityInvalidException : Exception
        {
            public QuantityInvalidException()
            {
            }

            public QuantityInvalidException(string message) : base(message)
            {
            }

            public QuantityInvalidException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected QuantityInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        [Serializable]
        internal class ModbusException : Exception
        {
            public ModbusException()
            {
            }

            public ModbusException(string message) : base(message)
            {
            }

            public ModbusException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected ModbusException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }

        [Serializable]
        internal class CRCCheckFailedException : Exception
        {
            public CRCCheckFailedException()
            {
            }

            public CRCCheckFailedException(string message) : base(message)
            {
            }

            public CRCCheckFailedException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected CRCCheckFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
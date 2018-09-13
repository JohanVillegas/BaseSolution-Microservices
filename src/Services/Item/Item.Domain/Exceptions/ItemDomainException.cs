using System;
using System.Collections.Generic;
using System.Text;

namespace Item.Domain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class ItemDomainException : Exception
    {
        public ItemDomainException()
        { }

        public ItemDomainException(string message)
            : base(message)
        { }

        public ItemDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

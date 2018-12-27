namespace SB.Domain.Exceptions
{
    using System;

    [Serializable]
    public sealed class HeaderFileSizeException : ApplicationException
    {
        public HeaderFileSizeException(string message)
            : base(message)
        {
        }
    }
}
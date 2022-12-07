namespace domain.casa.popular.Exceptions
{
    using System;
    public class CreateFamilyException : Exception {

        public CreateFamilyException(string message) :base(message) { }
        public CreateFamilyException(string message, Exception innerException) :base(message, innerException) { }
    }
}

namespace domain.casa.popular.Exceptions
{
    using System;
    public class CreatePersonException : Exception {

        public CreatePersonException(string message) :base(message) { }
        public CreatePersonException(string message, Exception innerException) :base(message, innerException) { }
    }
}

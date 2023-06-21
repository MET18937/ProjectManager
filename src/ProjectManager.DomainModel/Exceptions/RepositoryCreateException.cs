namespace ProjectManager.DomainModel.Exceptions
{
    public class RepositoryCreateException : Exception
    {
        public RepositoryCreateException()
            : base()
        { }

        public RepositoryCreateException(string message)
            : base(message)
        { }

        public RepositoryCreateException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

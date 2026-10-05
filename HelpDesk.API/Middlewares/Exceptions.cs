namespace HelpDesk.API.Middlewares.Exceptions
{
    /// <summary>Recurso não encontrado (HTTP 404).</summary>
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }

    /// <summary>Violação de regra de negócio / dado inválido (HTTP 400).</summary>
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }

    /// <summary>Credenciais inválidas (HTTP 401).</summary>
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string message) : base(message) { }
    }
}

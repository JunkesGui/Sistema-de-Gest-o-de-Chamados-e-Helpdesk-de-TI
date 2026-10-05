using HelpDesk.API.Middlewares.Exceptions;

namespace HelpDesk.API.Middlewares
{
    public record ErrorResponse(int StatusCode, string Mensagem, string TraceId);

    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (context.Response.HasStarted)
                {
                    _logger.LogWarning(ex, "A resposta já havia iniciado; não foi possível formatar o erro.");
                    throw;
                }

                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var (status, mensagem) = ex switch
            {
                NotFoundException => (StatusCodes.Status404NotFound, ex.Message),
                BusinessException => (StatusCodes.Status400BadRequest, ex.Message),
                UnauthorizedException => (StatusCodes.Status401Unauthorized, ex.Message),
                BadHttpRequestException => (StatusCodes.Status400BadRequest, "Requisição inválida."),
                _ => (StatusCodes.Status500InternalServerError,
                      "Ocorreu um erro interno. Tente novamente mais tarde.")
            };

            if (status >= 500)
                _logger.LogError(ex, "Erro não tratado. TraceId: {TraceId}", context.TraceIdentifier);
            else
                _logger.LogWarning("{Tipo}: {Mensagem}", ex.GetType().Name, ex.Message);

            context.Response.Clear();
            context.Response.StatusCode = status;

            await context.Response.WriteAsJsonAsync(
                new ErrorResponse(status, mensagem, context.TraceIdentifier));
        }
    }
}

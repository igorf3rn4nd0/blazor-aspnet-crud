using System.Net;
using Newtonsoft.Json;

namespace Server.Infrastructure.Middleware;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlingMiddleware> _logger;

    public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        
        var code = HttpStatusCode.InternalServerError; // 500 se inesperado
        
        var errorDetails = new
        {
            mensagem = "Ocorreu um erro interno no servidor. Por favor, tente novamente mais tarde.",
            detalhes = exception is HttpRequestException ? "Erro na solicitação HTTP." : "Erro interno do servidor."
        };
        
        _logger.LogError(exception, "Erro ao processar solicitação.");

        var result = JsonConvert.SerializeObject(errorDetails);
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        return context.Response.WriteAsync(result);
    }
}
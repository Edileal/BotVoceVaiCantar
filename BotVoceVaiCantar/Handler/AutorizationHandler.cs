using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;

namespace BotVoceVaiCantar.Handler
{
    public class AutorizationHandler : IAuthorizationMiddlewareResultHandler
    {
        private readonly IAuthorizationMiddlewareResultHandler _handler;

        public AutorizationHandler()
        {
            _handler = new AuthorizationMiddlewareResultHandler();
        }

        public async Task HandleAsync(
            RequestDelegate requestDelegate,
            HttpContext httpContext,
            AuthorizationPolicy authorizationPolicy,
            PolicyAuthorizationResult policyAuthorizationResult)
        {
            var informacaoResponse = new InformacaoResponse();

            if (!policyAuthorizationResult.Succeeded)
            {
                if (policyAuthorizationResult.Forbidden)
                {
                    httpContext.Response.StatusCode = 403;
                    informacaoResponse = new InformacaoResponse
                    {
                        Codigo = 403,
                        Mensagens = new List<string> { "Acesso não permitido" }
                    };
                }
                else
                {
                    httpContext.Response.StatusCode = 401;
                    informacaoResponse = new InformacaoResponse
                    {
                        Codigo = 401,
                        Mensagens = new List<string> { "Acesso negado" }
                    };
                }

                await httpContext.Response.WriteAsJsonAsync(informacaoResponse);
            }
            else
                await _handler.HandleAsync(requestDelegate, httpContext, authorizationPolicy, policyAuthorizationResult);
        }
    }
}


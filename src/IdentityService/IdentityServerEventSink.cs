using Duende.IdentityServer.Events;
using Duende.IdentityServer.Services;

namespace IdentityService;

public class IdentityServerEventSink(ILogger<IdentityServerEventSink> logger) : IEventSink
{
    public Task PersistAsync(Event evt)
    {
        if (evt is UserLoginFailureEvent userLoginFailureEvent)
        {
            logger.LogWarning("UserLoginFailure: {UserName} - {Message}", 
                userLoginFailureEvent.Username, 
                userLoginFailureEvent.Message);
        }
        
        if (evt is ClientAuthenticationSuccessEvent success)
        {
            logger.LogInformation("Client authenticated: {ClientId}", success.ClientId);
        }
        
        if (evt is ClientAuthenticationFailureEvent clientAuthenticationFailureEvent)
        {
            logger.LogWarning("ClientAuthenticationFailure: {ClientId} - {Message}", 
                clientAuthenticationFailureEvent.ClientId, 
                clientAuthenticationFailureEvent.Message);
        }
        
        
        if (evt is TokenIssuedSuccessEvent tokenIssuedSuccessEvent)
        {
            logger.LogInformation("TokenIssuedSuccess: {ClientId} - {Message}",
                tokenIssuedSuccessEvent.ClientId,
                tokenIssuedSuccessEvent.Message);
        }
        
        if (evt is TokenIssuedFailureEvent tokenIssuedFailureEvent)
        {
            logger.LogWarning("TokenIssuedFailure: {ClientId} - {Message}", 
                tokenIssuedFailureEvent.ClientId, 
                tokenIssuedFailureEvent.Message);
        }
        
        if (evt is ApiAuthenticationFailureEvent apiAuthenticationFailureEvent)
        {
            logger.LogWarning("ApiAuthenticationFailure: {ApiName} - {Message}", 
                apiAuthenticationFailureEvent.ApiName,
                apiAuthenticationFailureEvent.Message);
        }

        if (evt is TokenIntrospectionFailureEvent tokenIntrospectionFailureEvent)
        {
            logger.LogWarning("TokenIntrospectionFailure: {ApiName} - {ApiScopes} - {Message}", 
                tokenIntrospectionFailureEvent.ApiName, 
                tokenIntrospectionFailureEvent.ApiScopes,
                tokenIntrospectionFailureEvent.Message);
        }
        
        return Task.CompletedTask;
    }
}
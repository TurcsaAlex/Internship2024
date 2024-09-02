using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using TorqueAndTread.Server.Context;
using TorqueAndTread.Server.Services;

public class JwtMiddleware:IMiddleware
{
    private readonly List<string> validTokens= new();
    private readonly AuthService _authService;
    public JwtMiddleware(AuthService authService)
    {
        _authService = authService;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (context.Request.Path.StartsWithSegments("/api/auth"))
        {
            await next(context); // Skip the middleware and continue to the next component in the pipeline
            return;
        }

        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();


        if (token != null)
        {   
            if (!_authService.HasToken(token.ToString()))
            {
                await ReturnUnauthorised(context);
                return;
            }
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var username = jwtToken.Claims.FirstOrDefault(c => c.Type == "username")?.Value;

            if (!string.IsNullOrEmpty(username))
            {
                // Add the username to HttpContext for later use
                context.Items["Username"] = username;
            }

        }
        else {
            await ReturnUnauthorised(context);
            return;        
        }

        await next(context);
    }

    public async Task ReturnUnauthorised(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.StatusCode = 401; //UnAuthorized
        await context.Response.WriteAsync("Invalid User Key");
        return;
    }
}

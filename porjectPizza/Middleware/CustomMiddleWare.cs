using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using fileScdervices.Interface;


namespace porjectPizza.Middleware;

public class CustomMiddleWare
{

    private readonly RequestDelegate _next;
    private IfileServices<string> _IFileService;
    public CustomMiddleWare(RequestDelegate next, IfileServices<string> IFileService)
    {
        _next = next;
        _IFileService = IFileService;
    }

    public Task Invoke(HttpContext httpContext)
    {

        _IFileService.Write("time request"+DateTime.Now.ToString());
        _IFileService.Write("method"+httpContext.Request.Method.ToString());
        _IFileService.Write("header"+httpContext.Request.Headers.ToString());
        _IFileService.Write("body"+httpContext.Request.Body.ToString());
        // _IFileService.Write("action"+httpContext.GetEndpoint().ToString());

        var task=_next(httpContext);
        _IFileService.Write("time respomse"+DateTime.Now.ToString());
        _IFileService.Write("status"+httpContext.Response.StatusCode.ToString());
        return task;
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class CustomMiddleWareExtensions
{
    public static IApplicationBuilder UseCustom(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomMiddleWare>();
    }
}


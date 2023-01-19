public class TimeMiddleware{
    readonly RequestDelegate next;
    public TimeMiddleware(RequestDelegate nextRequest){
        next = nextRequest;
    }
    public async Task Invoke(HttpContext context) {
        await next(context); // Hace que se ejecute el siguiente middleware

        if (context.Request.Query.Any(p => p.Key == "time")) // Si el query string (http://localhost) trae el parametro time (localhost/api?time)
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString()); // Que escribe la hora al response
        }
    }
}

public static class TimeMiddlewareExtension{
    public static IApplicationBuilder UseTimeMiddlware(this IApplicationBuilder builder) {
        return builder.UseMiddleware<TimeMiddleware>();
    }
}
namespace BE_2505_NetCoreAPI
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(
        this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyCustomeMiddleware>();
        }
    }
}

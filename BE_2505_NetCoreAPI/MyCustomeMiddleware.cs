namespace BE_2505_NetCoreAPI
{
    public class MyCustomeMiddleware
    {
        private RequestDelegate _next;
        public MyCustomeMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            //return context.Response.WriteAsync("Custom Hello world!");
            return _next(context);
        }
    }
}

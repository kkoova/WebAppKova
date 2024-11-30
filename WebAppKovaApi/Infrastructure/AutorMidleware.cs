namespace WebAppKovaApi.Infrastructure
{
    public class AutorMidleware
    {
        private readonly RequestDelegate next;
        public AutorMidleware(RequestDelegate next) 
        { 
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.Headers.Add("Author", "Teacher");

            await next(context);
        }
    }
}

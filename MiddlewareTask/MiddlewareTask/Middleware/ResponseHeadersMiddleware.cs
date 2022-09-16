namespace MiddlewareTask.Middleware
{
    public class ResponseHeadersMiddleware
    {
        private readonly RequestDelegate _task;
        private readonly IConfiguration _config;

        public ResponseHeadersMiddleware(RequestDelegate task,IConfiguration config)
        {
            _task = task;
            _config = config;
        }
        public async Task Invoke(HttpContext context)
        {
            await _task.Invoke(context);

            var sections = _config.GetSection("CompanyInfo").GetChildren();
            foreach (var section in sections)
            {
                context.Response.Headers.Add(section.Key, section.Value);
            }

            //check if status code is 200 then add headers
            //if (context.Response.StatusCode == StatusCodes.Status200OK)
            //{
            //    var sections = _config.GetSection("CompanyInfo").GetChildren();
            //    foreach (var section in sections)
            //    {
            //        context.Response.Headers.Add(section.Key, section.Value);
            //    }
            //}
        }
    }
}

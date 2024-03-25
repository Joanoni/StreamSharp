using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace StreamSharp.Api.Controllers
{
    public class ProductStreamController : IActionResult
    {

        private readonly CancellationToken _requestAborted;
        private readonly Action<Stream, CancellationToken> _onStreaming;

        public ProductStreamController(Action<Stream, CancellationToken> onStreaming, CancellationToken requestAborted)
        {
            _requestAborted = requestAborted;
            _onStreaming = onStreaming;
        }

        public Task ExecuteResultAsync(ActionContext context)
        {
            var stream = context.HttpContext.Response.Body;
            context.HttpContext.Response.GetTypedHeaders().ContentType = new MediaTypeHeaderValue("text/event-stream");
            context.HttpContext.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
            {
                NoStore = true,
            };
            _onStreaming(stream, _requestAborted);
            return Task.CompletedTask;
        }
    }
}
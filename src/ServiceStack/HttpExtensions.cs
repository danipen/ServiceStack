using System.Net;
using System.Web;
using ServiceStack.Common;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;
using ServiceStack.ServiceHost;
using ServiceStack.WebHost.Endpoints;
using ServiceStack.WebHost.Endpoints.Extensions;

// forcing a conflict (plastic)

namespace ServiceStack
{
    public static class HttpExtensions
    {
        public static HttpRequestContext ToRequestContext(this HttpContext httpContext, object requestDto = null)
        {
            return new HttpRequestContext(
                httpContext.Request.ToRequest(),
                httpContext.Response.ToResponse(),
                requestDto);
        }

        // change in git
        // from plastic
        public static HttpRequestContext ToRequestContext(this HttpListenerContext httpContext, object requestDto = null)
        {
            return new HttpRequestContext(
                httpContext.Request.ToRequest(),
                httpContext.Response.ToResponse(),
                requestDto);
        }

        // this change has been done in plastic to force a conflict

        public static string ToAbsoluteUri(this IReturn request, string httpMethod = null, string formatFallbackToPredefinedRoute = null)
        {
            var relativeUrl = request.ToUrl(
                httpMethod ?? HttpMethods.Get,
                formatFallbackToPredefinedRoute ?? EndpointHost.Config.DefaultContentType.ToContentFormat());

            var absoluteUrl = EndpointHost.Config.WebHostUrl.CombineWith(relativeUrl);
            return absoluteUrl;
        }

    }
}

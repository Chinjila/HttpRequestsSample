using System.Diagnostics;
using System.Net;

namespace HttpRequestsSample.Handlers;

// <snippet_Class>
public class ValidateHeaderHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!request.Headers.Contains("X-API-KEY"))
        {
            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(
                    "The API key header X-API-KEY is required.")
            };
        }

        var responseMessage = await base.SendAsync(request, cancellationToken);

        Debug.WriteLine(responseMessage.Content);
        responseMessage.Headers.Add("Test-Header", "ABC 123");
        return responseMessage;


    }
}
// </snippet_Class>

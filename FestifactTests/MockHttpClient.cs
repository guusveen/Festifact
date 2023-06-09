using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Festifact.Models;

namespace FestifactTests
{
    public class MockHttpClient : IHttpClient
    {
        public HttpRequestMessage LastRequest { get; private set; }

        public virtual Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            LastRequest = new HttpRequestMessage(HttpMethod.Get, requestUri);
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }

        public virtual Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            LastRequest = new HttpRequestMessage(HttpMethod.Delete, requestUri);
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }

        public virtual Task<HttpResponseMessage> PostAsync(string requestUri, Organisator content)
        {
            LastRequest = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = new StringContent(JsonSerializer.Serialize(content), System.Text.Encoding.UTF8, "application/json")
            };
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }

        public virtual Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            LastRequest = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = content
            };
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }

        public virtual Task<HttpResponseMessage> PostAsJsonAsync(string requestUri, Organisator content, HttpResponseMessage expectedResponse)
        {
            LastRequest = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = new StringContent(JsonSerializer.Serialize(content), System.Text.Encoding.UTF8, "application/json")
            };
            return Task.FromResult(expectedResponse);
        }
        public virtual Task<HttpResponseMessage> PostAsJsonAsync(string requestUri, HttpContent content)
        {
            LastRequest = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = content
            };
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }

        public virtual Task<HttpResponseMessage> PutAsync(string requestUri, Organisator content)
        {
            LastRequest = new HttpRequestMessage(HttpMethod.Put, requestUri)
            {
                Content = new StringContent(JsonSerializer.Serialize(content), System.Text.Encoding.UTF8, "application/json")
            };
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }

        public virtual Task<HttpResponseMessage> PutAsJsonAsync(string requestUri, Organisator content, HttpResponseMessage expectedResponse)
        {
            LastRequest = new HttpRequestMessage(HttpMethod.Put, requestUri)
            {
                Content = new StringContent(JsonSerializer.Serialize(content), System.Text.Encoding.UTF8, "application/json")
            };
            return Task.FromResult(expectedResponse);
        }

        public virtual Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
        {
            LastRequest = new HttpRequestMessage(HttpMethod.Put, requestUri)
            {
                Content = content
            };
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }

        public Task<HttpResponseMessage> PutAsJsonAsync(string requestUri, HttpContent content)
        {
            LastRequest = new HttpRequestMessage(HttpMethod.Put, requestUri)
            {
                Content = content
            };
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }

        public virtual Task<HttpResponseMessage> PutAsJsonAsync<T>(string requestUri, T value)
        {
            LastRequest = new HttpRequestMessage(HttpMethod.Put, requestUri)
            {
                Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json")
            };
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }

        public virtual Task<HttpResponseMessage> PostAsJsonAsync<T>(string requestUri, T value)
        {
            LastRequest = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json")
            };
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK));
        }
    }
}

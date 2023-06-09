using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festifact.Models
{
    public interface IHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
        Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content);
        Task<HttpResponseMessage> PostAsJsonAsync(string requestUri, HttpContent content);
        Task<HttpResponseMessage> PostAsJsonAsync<T>(string requestUri, T value);
        Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content);
        Task<HttpResponseMessage> PutAsJsonAsync(string requestUri, HttpContent content);
        Task<HttpResponseMessage> PutAsJsonAsync<T>(string requestUri, T value);
        Task<HttpResponseMessage> DeleteAsync(string requestUri);
    }

}

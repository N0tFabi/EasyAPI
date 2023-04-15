using System.Net.Http.Headers;
using System.Net;

namespace EasyAPI
{
    public class EasyAPI
    {
        private readonly HttpClient _httpClient;

        public EasyAPI()
        {
            _httpClient = new HttpClient();
        }


        public async Task<string> GetAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAsync(string url, Dictionary<string, string> headers)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAsync(string url, string proxyHost, int proxyPort)
        {
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = new WebProxy(proxyHost, proxyPort)
            };
            var httpClient = new HttpClient(httpClientHandler);
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAsync(string url, Dictionary<string, string> headers, string proxyHost, int proxyPort)
        {
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = new WebProxy(proxyHost, proxyPort)
            };
            var httpClient = new HttpClient(httpClientHandler);
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }


        public async Task<string> PostAsync(string url, string data)
        {
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync(string url, string data, string proxyHost, int proxyPort)
        {
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = new WebProxy(proxyHost, proxyPort)
            };
            var httpClient = new HttpClient(httpClientHandler);
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }


        public async Task<string> GetJsonAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }

        public async Task<string> GetJsonAsync(string url, string proxyHost, int proxyPort)
        {
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = new WebProxy(proxyHost, proxyPort)
            };
            var httpClient = new HttpClient(httpClientHandler);
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            return json;
        }


        public async Task<byte[]> GetByteArrayAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }

        public async Task<byte[]> GetByteArrayAsync(string url, string proxyHost, int proxyPort)
        {
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = new WebProxy(proxyHost, proxyPort)
            };
            var httpClient = new HttpClient(httpClientHandler);
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsByteArrayAsync();
        }


        public async Task<string> PutAsync(string url, string data)
        {
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> PutAsync(string url, string data, string proxyHost, int proxyPort)
        {
            var content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = new WebProxy(proxyHost, proxyPort)
            };
            var httpClient = new HttpClient(httpClientHandler);
            var response = await httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }


        public async Task<string> DeleteAsync(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteAsync(string url, string proxyHost, int proxyPort)
        {
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = new WebProxy(proxyHost, proxyPort)
            };
            var httpClient = new HttpClient(httpClientHandler);
            var response = await httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }


        public async Task<string> UploadFileAsync(string url, string filePath)
        {
            var content = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(await File.ReadAllBytesAsync(filePath));
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            content.Add(fileContent, "file", Path.GetFileName(filePath));
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> UploadFileAsync(string url, string filePath, string proxyHost, int proxyPort)
        {
            var content = new MultipartFormDataContent();
            var fileContent = new ByteArrayContent(await File.ReadAllBytesAsync(filePath));
            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
            content.Add(fileContent, "file", Path.GetFileName(filePath));
            var httpClientHandler = new HttpClientHandler
            {
                Proxy = new WebProxy(proxyHost, proxyPort)
            };
            var httpClient = new HttpClient(httpClientHandler);
            var response = await httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }


        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}

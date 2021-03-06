﻿using BookStoreUI.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreUI.Services
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly IHttpClientFactory HttpClient;

        public BaseRepository(IHttpClientFactory httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<bool> Create(string url, T obj)
        {
            if(obj == null)
            {
                return false;
            }

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(JsonConvert.SerializeObject(obj));

            var client = HttpClient.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if(response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(string url, int id)
        {
            if(id < 1)
            {
                return false;
            }

            var request = new HttpRequestMessage(HttpMethod.Delete, url + id);
            var client = HttpClient.CreateClient();

            HttpResponseMessage responseMessage = await client.SendAsync(request);

            if(responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }

            return false;
        }

        public async Task<T> Get(string url, int id)
        {
            if(id < 1)
            {
                return null;
            }

            var request = new HttpRequestMessage(HttpMethod.Get, url + id);
            var client = HttpClient.CreateClient();

            HttpResponseMessage responseMessage = await client.SendAsync(request);

            if(responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }

            return null;
        }

        public async Task<IList<T>> Get(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = HttpClient.CreateClient();

            HttpResponseMessage httpResponseMessage = await client.SendAsync(request);

            if(httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<T>>(content);
            }

            return Array.Empty<T>();
        }

        public async Task<bool> Update(string url, T obj, int id)
        {
            if(obj == null && id < 1)
            {
                return false;
            }

            var request = new HttpRequestMessage(HttpMethod.Put, url + id);
            request.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var client = HttpClient.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);
            if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }

            return false;
        }
    }
}

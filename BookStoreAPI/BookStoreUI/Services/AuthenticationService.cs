using BookStoreUI.Contracts;
using BookStoreUI.Models;
using BookStoreUI.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreUI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpClientFactory HttpClient;

        public AuthenticationService(IHttpClientFactory httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<bool> Registration(RegistrationModel registrationModel)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, Endpoints.RegisterUrl);
            request.Content = new StringContent(JsonConvert.SerializeObject(registrationModel), Encoding.UTF8, "application/json");

            var client = HttpClient.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            return response.IsSuccessStatusCode;
        }
    }
}

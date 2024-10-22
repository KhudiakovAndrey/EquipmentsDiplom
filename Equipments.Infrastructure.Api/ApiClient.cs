﻿
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Equipments.Api.Extensions;
using Equipments.AvaloniaUI.Services;

namespace Equipments.Api
{
    public class ApiClient
    {
        private readonly string _baseAddress;
        private readonly HttpClient _httpClient;
        public string? AccessToken { get; set; }
        public event EventHandler TokenExpired;
        public ApiClient(string baseAddress)
        {
            _baseAddress = baseAddress;
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseAddress) };
        }
        public ApiClient(string baseAddress, string accessToken)
        {
            _baseAddress = baseAddress;
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseAddress) };
            AccessToken = accessToken;
        }
        public async Task<ApiResponse<T>> GetAsync<T>(string requestUrl)
        {
            bool succes = SetDefaultRequestHeadersAuthorization();
            if (!succes)
                return new ApiResponse<T>();

            var response = await _httpClient.GetAsync(_baseAddress + requestUrl);
            return await HandleResponse<T>(response);
        }
        public async Task<ApiResponse<T>> GetAsync<T>(string requestUrl, object content)
        {
            bool succes = SetDefaultRequestHeadersAuthorization();
            if (!succes)
                return new ApiResponse<T>();

            string query = content.ToQueryString();
            var response = await _httpClient.GetAsync(_baseAddress + requestUrl + "?" + query);
            return await HandleResponse<T>(response);
        }

        public async Task<ApiResponse<T>> PostAsync<T>(string requestUrl, object content)
        {
            bool succes = SetDefaultRequestHeadersAuthorization();
            if (!succes)
                return new ApiResponse<T>();
            var jsonContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            string res = jsonContent.ReadAsStringAsync().Result;
            var response = await _httpClient.PostAsync(_baseAddress + requestUrl, jsonContent);
            return await HandleResponse<T>(response);
        }
        public async Task<ApiResponse<T>> PutAsync<T>(string requestUrl, object content = null)
        {
            bool succes = SetDefaultRequestHeadersAuthorization();
            if (!succes)
                return new ApiResponse<T>();

            var jsonContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            Console.WriteLine(jsonContent.ReadAsStringAsync());
            var responce = await _httpClient.PutAsync(_baseAddress + requestUrl, jsonContent);
            return await HandleResponse<T>(responce);
        }
        public async Task<ApiResponse<T>> DeleteAsync<T>(string requestUrl)
        {
            bool succes = SetDefaultRequestHeadersAuthorization();
            if (!succes)
                return new ApiResponse<T>();
            var response = await _httpClient.DeleteAsync(_baseAddress + requestUrl);
            return await HandleResponse<T>(response);
        }

        public async Task<ApiResponse<T>> HandleResponse<T>(HttpResponseMessage response)
        {
            var apiResponse = new ApiResponse<T>();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                apiResponse.Data = JsonConvert.DeserializeObject<T>(content, new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                })!;
                apiResponse.IsSucces = true;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                apiResponse.Message = JsonConvert.DeserializeObject<ErrorResponse>(content)!;
                apiResponse.IsSucces = false;
            }

            apiResponse.StatusCode = (int)response.StatusCode;

            return apiResponse;
        }

        private bool SetDefaultRequestHeadersAuthorization()
        {
            if (!string.IsNullOrEmpty(AccessToken))
            {
                if (!TokenService.ValidToToken(AccessToken))
                {
                    TokenExpired?.Invoke(this, EventArgs.Empty);
                    return false;
                }
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            }
            return true;
        }
    }
}

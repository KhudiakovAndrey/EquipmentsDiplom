﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Equipments.Api
{
    public class ApiClient
    {
        private readonly string _baseAddress;
        private readonly HttpClient _httpClient;
        public string? AccessToken { get; set; }
        public ApiClient(string baseAddress)
        {
            _baseAddress = baseAddress;
            _httpClient = new HttpClient { BaseAddress = new Uri(_baseAddress) };
        }
        public async Task<ApiResponse<T>> GetAsync<T>(string requestUrl)
        {
            if (!string.IsNullOrEmpty(AccessToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            }

            var response = await _httpClient.GetAsync(requestUrl);
            return await HandleResponse<T>(response);
        }

        public async Task<ApiResponse<T>> PostAsync<T>(string requestUrl, object content)
        {
            if (!string.IsNullOrEmpty(AccessToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            }

            var jsonContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(requestUrl, jsonContent);
            return await HandleResponse<T>(response);
        }
        public async Task<ApiResponse<T>> PutAsync<T>(string requestUrl, object content)
        {
            if (!string.IsNullOrEmpty(AccessToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            }

            var jsonContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
            var responce = await _httpClient.PutAsync(requestUrl, jsonContent);
            return await HandleResponse<T>(responce);
        }
        public async Task<ApiResponse<bool>> DeleteAsync(string requestUrl)
        {
            if (!string.IsNullOrEmpty(AccessToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            }

            var response = await _httpClient.DeleteAsync(requestUrl);
            return await HandleResponse<bool>(response);
        }

        public async Task<ApiResponse<T>> HandleResponse<T>(HttpResponseMessage response)
        {
            var apiResponse = new ApiResponse<T>();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                apiResponse.Data = JsonConvert.DeserializeObject<T>(content)!;
                apiResponse.IsSucces = true;
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                apiResponse.Message = content;
                apiResponse.IsSucces = false;
            }

            apiResponse.StatusCode = (int)response.StatusCode;

            return apiResponse;
        }
    }
}
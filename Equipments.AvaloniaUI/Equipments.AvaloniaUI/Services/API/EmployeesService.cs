﻿using Equipments.Api;
using Equipments.AvaloniaUI.Data;
using Equipments.AvaloniaUI.Models;
using Equipments.AvaloniaUI.Resources;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Equipments.AvaloniaUI.Services.API
{
    public class EmployeesService : ApiService
    {
        private readonly AppConfiguration _appConfiguration;

        public EmployeesService(AppConfiguration appConfiguration)
            : base(appConfiguration.WebApiUrl)
        {
            _appConfiguration = appConfiguration;
            TokenExpiredEventHandler.RegisterApiService(this);
        }

        public async Task<ApiResponse<List<EmployeModel>>> GetEmployees()
        {
            var response = await GetAsync<List<EmployeModel>>(_appConfiguration.EmployeesEndpoint);
            return response;
        }
        public async Task<ApiResponse<FullEmployeModel>> GetMeEmploye()
        {
            var response = await GetAsync<FullEmployeModel>(_appConfiguration.EmployeesEndpoint + "/me");
            return response;
        }
        public async Task<ApiResponse<object>> PutImageAsync(Guid id, byte[] imageBytes)
        {
            var response = await PutAsync<object>(_appConfiguration.EmployeesEndpoint + $"/{id}/image", imageBytes);
            return response;
        }
        public async Task<ApiResponse<object>> SetDefaultImageAsync(Guid id)
        {
            var response = await PutAsync<object>(_appConfiguration.EmployeesEndpoint + $"/{id}/image/default");
            return response;
        }
        public async Task<ApiResponse<IEnumerable<ReportEmployeByDepartmentModel>>> GetAllByDepartment(int idDepartment)
        {
            var response = await GetAsync<IEnumerable<ReportEmployeByDepartmentModel>>(_appConfiguration.EmployeesEndpoint + $"/by-department/{idDepartment}");
            return response;
        }
    }
}

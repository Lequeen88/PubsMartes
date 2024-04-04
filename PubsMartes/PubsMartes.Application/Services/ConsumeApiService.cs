<<<<<<< HEAD
﻿using System.Text;
using Microsoft.Extensions.Configuration;
=======
﻿using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
>>>>>>> Implementacion de la capa de servicio Parte II
using Newtonsoft.Json;
using PubsMartes.Application.Contract;
using PubsMartes.Application.Dtos.Jobs;

namespace PubsMartes.Application.Services;

public class ConsumeApiService : IConsumeApiService
{
<<<<<<< HEAD
    private readonly HttpClient _httpClient;

    public ConsumeApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        var apiUrl = configuration.GetValue<string>("ApiUrl");
        _httpClient.BaseAddress = new Uri(apiUrl);
=======
    public static IConfiguration? Configuration;
    public static IHttpClientFactory Factory;

    public ConsumeApiService(IConfiguration configuration, IHttpClientFactory factory)
    {
        Configuration = configuration;
        Factory = factory;
>>>>>>> Implementacion de la capa de servicio Parte II
    }

    public async Task<JonDetailsResult> GetAllJobs()
    {
        try
        {
<<<<<<< HEAD
            var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}GetJobs");
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<JonDetailsResult>(json);
            return result;
=======
            using (var client = Factory.CreateClient("JobApi"))
            {
                var response = await client.GetAsync($"{client.BaseAddress}GetJobs");
                if (!response.IsSuccessStatusCode) return null;
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<JonDetailsResult>(json);
                return result;
            }
>>>>>>> Implementacion de la capa de servicio Parte II
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al intentar consumir el api en GetAllJobs", ex);
        }
    }

    public async Task CreateJob(JobsDtoAdd model)
    {
        try
        {
<<<<<<< HEAD
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_httpClient.BaseAddress}SaveJobs", content);

            if (response.IsSuccessStatusCode)
            {
            }
=======
            using (var client = Factory.CreateClient("JobApi"))
            {
                var content = GetJsonContent(model);
                var response = await client.PostAsync($"{client.BaseAddress}SaveJobs", content);
            }

>>>>>>> Implementacion de la capa de servicio Parte II
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error al intentar insertar en la API", e);
        }
    }

    public async Task<JobsDtoUpdate> GetJobById(int id)
    {
        try
        {
<<<<<<< HEAD
            var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}GetJobsByID?ID={id}");
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<JobUpdateResult>(json);
            return data.data;
=======
            using (var client = Factory.CreateClient("JobApi"))
            {
                var response = await client.GetAsync($"{client.BaseAddress}GetJobsByID?ID={id}");
                if (!response.IsSuccessStatusCode) return null;

                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<JobUpdateResult>(json);
                return data.data;
            }

>>>>>>> Implementacion de la capa de servicio Parte II
        }
        catch (Exception e)
        {
            throw new ApplicationException("", e);
        }
    }

    public async Task EditJob(int id, JobsDtoUpdate request)
    {
        try
        {
<<<<<<< HEAD
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_httpClient.BaseAddress}UpdateJobs", content);
            if (response.IsSuccessStatusCode)
            {
                var stringJson = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<JobUpdateResult>(stringJson);
            }
            var error = await response.Content.ReadAsStringAsync();
=======
            using (var client = Factory.CreateClient("JobApi"))
            {
                var content = GetJsonContent(request);
                var response = await client.PutAsync($"{client.BaseAddress}UpdateJobs", content);
                if (response.IsSuccessStatusCode)
                {
                    var stringJson = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<JobUpdateResult>(stringJson);
                }
                var error = await response.Content.ReadAsStringAsync();
            }

>>>>>>> Implementacion de la capa de servicio Parte II
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error al intentar editar", ex);
        }
    }

    public async Task<JobDtoRemove> GetDeleteModel(int id)
    {
        var job = await GetJobById(id);
        var deleteJob = new JobDtoRemove
        {
            Deleted = false,
            ChangeDate = DateTime.Now,
            JobID = job.JobID,
            ChangeUser = job.ChangeUser,
        };
        return deleteJob;
    }

    public async Task Delete(JobDtoRemove request)
    {
        try
        {
<<<<<<< HEAD
            var jobModel = await GetDeleteModel(request.JobID);
            var json = JsonConvert.SerializeObject(jobModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_httpClient.BaseAddress}DeleteJobs", content);
            if (!response.IsSuccessStatusCode)
            {
                var stringJson = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<JobUpdateResult>(stringJson);
            }
=======
            using (var client = Factory.CreateClient("JobApi"))
            {
                var jobModel = await GetDeleteModel(request.JobID);
                var content = GetJsonContent(jobModel);
                var response = await client.PostAsync($"{client.BaseAddress}DeleteJobs", content);
                if (!response.IsSuccessStatusCode)
                {
                    var stringJson = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<JobUpdateResult>(stringJson);
                }
            }

>>>>>>> Implementacion de la capa de servicio Parte II
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error al intentar borrar el job", e);
        }
    }
<<<<<<< HEAD
=======

    private StringContent GetJsonContent(dynamic model)
    {
        var json = JsonConvert.SerializeObject(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        return content;
    }

>>>>>>> Implementacion de la capa de servicio Parte II
}
using System.Text;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PubsMartes.Application.Contract;
using PubsMartes.Application.Dtos.Jobs;

namespace PubsMartes.Application.Services;

public class ConsumeApiService : IConsumeApiService
{
    private readonly HttpClient _httpClient;

    public ConsumeApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        var apiUrl = configuration.GetValue<string>("ApiUrl");
        _httpClient.BaseAddress = new Uri(apiUrl);
    }

    public async Task<JonDetailsResult> GetAllJobs()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}GetJobs");
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<JonDetailsResult>(json);
            return result;
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
            var json = JsonConvert.SerializeObject(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_httpClient.BaseAddress}SaveJobs", content);

            if (response.IsSuccessStatusCode)
            {
            }
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
            var response = await _httpClient.GetAsync($"{_httpClient.BaseAddress}GetJobsByID?ID={id}");
            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<JobUpdateResult>(json);
            return data.data;
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
            var json = JsonConvert.SerializeObject(request);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_httpClient.BaseAddress}UpdateJobs", content);
            if (response.IsSuccessStatusCode)
            {
                var stringJson = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<JobUpdateResult>(stringJson);
            }
            var error = await response.Content.ReadAsStringAsync();
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
            var jobModel = await GetDeleteModel(request.JobID);
            var json = JsonConvert.SerializeObject(jobModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_httpClient.BaseAddress}DeleteJobs", content);
            if (!response.IsSuccessStatusCode)
            {
                var stringJson = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<JobUpdateResult>(stringJson);
            }
        }
        catch (Exception e)
        {
            throw new ApplicationException("Error al intentar borrar el job", e);
        }
    }
}
using System.Diagnostics;
using System.Net.Http.Headers;
using Client.Models;
using Client.Models.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Services;

public interface IHttpService
{
    public Task<DataResult> Get(string path, string token);
    public Task<DataResult> Post(string path, string token, object body);
}

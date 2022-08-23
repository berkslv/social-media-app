using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using Client.Models;
using Client.Models.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Services;

public class HttpService : IHttpService
{
    private string URL = "http://localhost:5000/api";

    public async Task<DataResult> Get(string path, string token)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //GET Method
            HttpResponseMessage response = await client.GetAsync($"{URL}{path}");

            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadFromJsonAsync<DataResult>();

                return str;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
    }

    public async Task<DataResult> Post(string path, string token, object body)
    {
        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //GET Method
            HttpResponseMessage response = await client.PostAsJsonAsync($"{URL}{path}",body);

            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadFromJsonAsync<DataResult>();
                // var res = JsonConvert.DeserializeObject(str.Data.ToString());

                return str;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                return null;
            }
        }
    }
}

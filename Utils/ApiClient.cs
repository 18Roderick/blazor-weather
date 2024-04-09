using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace blazor_weather.Utils
{
    public class ApiClient
    {
        private readonly HttpClient _http;
        public ApiClient(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient( );
        }



        public async Task GetWeatherAsync(){

          var data = await  this._http.GetFromJsonAsync<dynamic>("");
          Console.WriteLine(data);
        }
    }
}
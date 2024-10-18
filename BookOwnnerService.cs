using GetAllBooksAPI;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
//using GetAllBooksAPI.Bookqwner;

namespace GetAllBooksAPI
{
    public class BookOwnnerService
    {

        private readonly HttpClient _httpClient;

        public BookOwnnerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Bookowner>> GetBookOwnersAsync()
        {
            var response = await _httpClient.GetAsync("https://digitalcodingtest.bupa.com.au/api/v1/bookowners");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Error fetching book owners.");
            }

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Bookowner>>(content);
        }





    }
}






    
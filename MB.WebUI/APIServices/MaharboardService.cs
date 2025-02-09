using MB.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Newtonsoft.Json;

namespace MB.WebUI.APIServices
{
    public class MaharboardService
    {
        private readonly HttpClient httpClient;
        public MaharboardService(IHttpClientFactory httpClientFactory)
        {
            this.httpClient = httpClientFactory.CreateClient("MaharboardService");
        }

        public async Task<Maharboard> GetMaharboardResult(Maharboard mahaboard)
        {
            try
            {
                var response = await httpClient.PostAsJsonAsync("/MaharBoard", mahaboard);
                if (response.IsSuccessStatusCode)
                {
                    string jsonstring = await response.Content.ReadAsStringAsync();
                    
                    mahaboard = JsonConvert.DeserializeObject<Maharboard>(jsonstring);
                    return mahaboard;
                }
                return new Maharboard();
            }
            catch (Exception ex)
            {
                return mahaboard;
            }
        }
    }

}

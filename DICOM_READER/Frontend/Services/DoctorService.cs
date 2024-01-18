using DatabaseHanlder.Models;
using System.Net.Http.Json;

namespace Frontend.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HttpClient httpClient;

        public DoctorService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Patient>> getPacientsOfDoktor(string doctorID)
        {
            var url = $"Pacients/{doctorID}";
            var data = await this.httpClient.GetFromJsonAsync<IEnumerable<Patient>>(url);


            return data;
        }
    }
}

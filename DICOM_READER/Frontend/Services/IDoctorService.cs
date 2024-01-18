using DatabaseHanlder.Models;
using System.Net.Http.Json;

namespace Frontend.Services
{
    public interface IDoctorService
    {
       Task<IEnumerable<Patient>> getPacientsOfDoktor(string doctorID);
    }
}

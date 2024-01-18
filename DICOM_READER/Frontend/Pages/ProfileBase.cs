using DatabaseHanlder.Models;
using Frontend.Services;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages
{
    public class ProfileBase:ComponentBase
    {
        [Inject]
        public IDoctorService DoctorService { get; set; }
        public IEnumerable<Patient> Patients { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Patients = await DoctorService.getPacientsOfDoktor("DC1234");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseHanlder.Models;

namespace DP_WebApi.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ModelContext _context;

        public PatientsController(ModelContext context)
        {
            _context = context;
        }

        [HttpGet("patientsDetail/{doctorID}/{patientID}")]
        public async Task<ActionResult<List<Patient>>> getDetail(string doctorID, string patientID)
        {
            var data = await _context.Examinations
                .Where(e => e.PatientId == patientID && e.DoctorId == doctorID)
                .OrderBy(e => e.ExamDate)
                .ToListAsync();

            return Ok(data);
        }
    }
}

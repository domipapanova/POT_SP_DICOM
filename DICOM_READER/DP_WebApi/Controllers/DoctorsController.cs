using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DatabaseHanlder.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DP_WebApi.Extensions.Dtos;

namespace DP_WebApi.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly ModelContext _context;

        public DoctorsController(ModelContext context)
        {
            _context = context;
        }


        [HttpGet("AllDoctors")]
        public async Task<ActionResult<List<DoctorDto>>> GetAllDoctors()
        {
           
            var data = await _context.Doctors
                .OrderBy(x => x.DoctorId)
                .ToArrayAsync();

            if (data == null)
            {
                return NotFound();
            }
            else 
            {
                return Ok(data);
            }
        }

        [HttpGet("Pacients/{doctorID}")]
        public async Task<ActionResult<IEnumerable<Patient>>> getPacientsOfDoktor(string doctorID)
        {
            var data = await _context.Patients
                .Include(p => p.Examinations)
                .Where(p => p.Examinations.Any(e => e.DoctorId == doctorID))
                .ToListAsync();
            if (data == null)
            { 
                return NotFound(); 
            }

            return Ok(data);
        }

        /// <summary>
        /// Method for genetarting JWT Token to store informations about logged user
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>JWT token</returns>
        /// resource: https://www.c-sharpcorner.com/article/jwt-json-web-token-authentication-in-asp-net-core/


        [HttpGet("GetToken/{login}/{password}")]
        public async Task<ActionResult<string>> getTokenOfDoctor(string login, string password)
        {
            var data = await _context
                 .Doctors
                 .Where(d => d.DoctorId == login && d.PasswordHash == password)
                 .FirstOrDefaultAsync();

            if (data != null)
            {
                var doctorId = data.DoctorId;
                var name = data.DoctorName;
                var surname = data.DoctorSurname;
                var speciality = data.Specialty;
                var claims = new[]
                {
                   new Claim("name", name),
                   new Claim("surname", surname),
                   new Claim("speciality", speciality),
                   new Claim("doctorId", doctorId)
                 };

                //at least 32 characters
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("abcdefgh12345678abcdefgh12345678"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddYears(1),
                    signingCredentials: creds);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(jwt);

            }

            return BadRequest("No matched user for login/password");
        }
    }
}

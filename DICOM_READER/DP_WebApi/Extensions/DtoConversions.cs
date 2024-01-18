using DatabaseHanlder.Models;
using DP_WebApi.Extensions.Dtos;

namespace DP_WebApi.Extensions
{
    public static class DtoConversions
    {
        public static IEnumerable<DoctorDto> ConvertToDto(this IEnumerable<Doctor> products)
        {
            return NotImplementedException();
        }

        private static IEnumerable<DoctorDto> NotImplementedException()
        {
            throw new NotImplementedException();
        }
    }
}

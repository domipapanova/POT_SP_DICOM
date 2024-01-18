namespace DP_WebApi.Extensions.Dtos
{
    public class ExaminationDto
    {
        public int ExamId { get; set; }
        public string? PatientId { get; set; }
        public DateOnly? ExamDate { get; set; }
        public string? Notes { get; set; }
        public string DoctorId { get; set; } 

    }
}

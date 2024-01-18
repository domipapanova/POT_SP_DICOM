using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHanlder.Models;

[Table("examination")]
public partial class Examination
{
    [Key]
    [Column("exam_id")]
    public int ExamId { get; set; }

    [Column("patient_id")]
    [StringLength(10)]
    public string? PatientId { get; set; }

    [Column("exam_date")]
    public DateOnly? ExamDate { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("doctor_id")]
    [StringLength(6)]
    public string DoctorId { get; set; } = null!;

    [ForeignKey("DoctorId")]
    [InverseProperty("Examinations")]
    public virtual Doctor Doctor { get; set; } = null!;

    [InverseProperty("Exam")]
    public virtual ICollection<File> Files { get; set; } = new List<File>();

    [ForeignKey("PatientId")]
    [InverseProperty("Examinations")]
    public virtual Patient? Patient { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHanlder.Models;

[Table("doctor")]
public partial class Doctor
{
    [Column("doctor_name")]
    [StringLength(100)]
    public string DoctorName { get; set; } = null!;

    [Column("doctor_surname")]
    [StringLength(20)]
    public string DoctorSurname { get; set; } = null!;

    [Column("password_hash")]
    [StringLength(100)]
    public string PasswordHash { get; set; } = null!;

    [Column("specialty")]
    [StringLength(100)]
    public string? Specialty { get; set; }

    [Key]
    [Column("doctor_id", TypeName = "character varying")]
    public string DoctorId { get; set; } = null!;

    [InverseProperty("Doctor")]
    public virtual ICollection<Examination> Examinations { get; set; } = new List<Examination>();
}

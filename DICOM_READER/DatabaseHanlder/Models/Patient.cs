using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHanlder.Models;

[Table("patient")]
public partial class Patient
{
    [Key]
    [Column("patient_id")]
    [StringLength(10)]
    public string PatientId { get; set; } = null!;

    [Column("patient_name")]
    [StringLength(20)]
    public string PatientName { get; set; } = null!;

    [Column("patient_surname")]
    [StringLength(20)]
    public string PatientSurname { get; set; } = null!;

    [Column("email", TypeName = "character varying")]
    public string? Email { get; set; }

    [Column("phone_number")]
    [StringLength(13)]
    public string? PhoneNumber { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [JsonIgnore]
    [InverseProperty("Patient")]
    public virtual ICollection<Examination> Examinations { get; set; } = new List<Examination>();
}

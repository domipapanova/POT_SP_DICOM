using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHanlder.Models;

[Table("files")]
public partial class File
{
    [Key]
    [Column("dicom_id")]
    public int DicomId { get; set; }

    [Column("exam_id")]
    public int? ExamId { get; set; }

    [Column("file_name")]
    [StringLength(255)]
    public string? FileName { get; set; }

    [Column("file_data")]
    public byte[]? FileData { get; set; }

    [ForeignKey("ExamId")]
    [InverseProperty("Files")]
    public virtual Examination? Exam { get; set; }
}

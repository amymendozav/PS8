using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("GRADE")]
public partial class Grade
{
    [Key]
    [Column("GRADE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string GradeGuid { get; set; } = null!;

    [Column("STUDENT_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string StudentGuid { get; set; } = null!;

    [Column("SECTION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string SectionGuid { get; set; } = null!;

    [Column("GRADE_TYPE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string GradeTypeGuid { get; set; } = null!;

    [Column("GRADE_CODE_OCCURRENCE", TypeName = "NUMBER(38)")]
    public decimal GradeCodeOccurrence { get; set; }

    [Column("NUMERIC_GRADE")]
    [Precision(3)]
    public byte NumericGrade { get; set; }

    [Column("COMMENTS")]
    [StringLength(2000)]
    [Unicode(false)]
    public string? Comments { get; set; }

    [Column("CREATED_BY")]
    [StringLength(30)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column("CREATED_DATE", TypeName = "DATE")]
    public DateTime CreatedDate { get; set; }

    [Column("MODIFIED_BY")]
    [StringLength(30)]
    [Unicode(false)]
    public string ModifiedBy { get; set; } = null!;

    [Column("MODIFIED_DATE", TypeName = "DATE")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("GradeTypeGuid")]
    [InverseProperty("Grade")]
    public virtual GradeType GradeType { get; set; } = null!;

    [ForeignKey("SectionGuid")]
    [InverseProperty("Grade")]
    public virtual Section Section { get; set; } = null!;

    [ForeignKey("StudentGuid")]
    [InverseProperty("Grade")]
    public virtual Student Student { get; set; } = null!;
}

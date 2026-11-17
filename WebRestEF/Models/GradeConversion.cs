using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("GRADE_CONVERSION")]
[Index("LetterGrade", Name = "GRADE_CONVERSION_UK1", IsUnique = true)]
public partial class GradeConversion
{
    [Key]
    [Column("GRADE_CONVERSION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string GradeConversionGuid { get; set; } = null!;

    [Column("LETTER_GRADE")]
    [StringLength(2)]
    [Unicode(false)]
    public string LetterGrade { get; set; } = null!;

    [Column("GRADE_POINT", TypeName = "NUMBER(3,2)")]
    public decimal GradePoint { get; set; }

    [Column("MAX_GRADE")]
    [Precision(3)]
    public byte MaxGrade { get; set; }

    [Column("MIN_GRADE")]
    [Precision(3)]
    public byte MinGrade { get; set; }

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
}

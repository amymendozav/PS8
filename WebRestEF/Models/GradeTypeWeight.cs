using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("GRADE_TYPE_WEIGHT")]
public partial class GradeTypeWeight
{
    [Key]
    [Column("GRADE_TYPE_WEIGHT_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string GradeTypeWeightGuid { get; set; } = null!;

    [Column("SECTION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string SectionGuid { get; set; } = null!;

    [Column("GRADE_TYPE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string GradeTypeGuid { get; set; } = null!;

    [Column("NUMBER_PER_SECTION")]
    [Precision(3)]
    public byte NumberPerSection { get; set; }

    [Column("PERCENT_OF_FINAL_GRADE")]
    [Precision(3)]
    public byte PercentOfFinalGrade { get; set; }

    [Column("DROP_LOWEST")]
    [StringLength(1)]
    [Unicode(false)]
    public string DropLowest { get; set; } = null!;

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
    [InverseProperty("GradeTypeWeight")]
    public virtual GradeType GradeType { get; set; } = null!;

    [ForeignKey("SectionGuid")]
    [InverseProperty("GradeTypeWeight")]
    public virtual Section Section { get; set; } = null!;
}

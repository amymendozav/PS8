using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("GRADE_TYPE")]
[Index("GradeTypeCode", Name = "GRADE_TYPE_UK1", IsUnique = true)]
public partial class GradeType
{
    [Key]
    [Column("GRADE_TYPE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string GradeTypeGuid { get; set; } = null!;

    [Column("GRADE_TYPE_CODE")]
    [StringLength(2)]
    [Unicode(false)]
    public string GradeTypeCode { get; set; } = null!;

    [Column("DESCRIPTION")]
    [StringLength(50)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

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

    [InverseProperty("GradeType")]
    public virtual ICollection<Grade> Grade { get; set; } = new List<Grade>();

    [InverseProperty("GradeType")]
    public virtual ICollection<GradeTypeWeight> GradeTypeWeight { get; set; } = new List<GradeTypeWeight>();
}

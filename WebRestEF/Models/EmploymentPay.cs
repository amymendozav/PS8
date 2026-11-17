using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("EMPLOYMENT_PAY")]
public partial class EmploymentPay
{
    [Key]
    [Column("EMPLOYMENT_PAY_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string EmploymentPayGuid { get; set; } = null!;

    [Column("EMPLOYMENT_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string EmploymentGuid { get; set; } = null!;

    [Column("SALARY", TypeName = "NUMBER(8,2)")]
    public decimal Salary { get; set; }

    [Column("COMMISSION_PCT", TypeName = "NUMBER(2,2)")]
    public decimal? CommissionPct { get; set; }

    [Column("CREATED_BY")]
    [StringLength(32)]
    [Unicode(false)]
    public string CreatedBy { get; set; } = null!;

    [Column("CREATED_DATE", TypeName = "DATE")]
    public DateTime CreatedDate { get; set; }

    [Column("MODIFIED_BY")]
    [StringLength(32)]
    [Unicode(false)]
    public string ModifiedBy { get; set; } = null!;

    [Column("MODIFIED_DATE", TypeName = "DATE")]
    public DateTime ModifiedDate { get; set; }

    [ForeignKey("EmploymentGuid")]
    [InverseProperty("EmploymentPay")]
    public virtual Employment Employment { get; set; } = null!;
}

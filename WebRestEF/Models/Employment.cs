using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("EMPLOYMENT")]
public partial class Employment
{
    [Key]
    [Column("EMPLOYMENT_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string EmploymentGuid { get; set; } = null!;

    [Column("EMPLOYEE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string EmployeeGuid { get; set; } = null!;

    [Column("JOB_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string JobGuid { get; set; } = null!;

    [Column("DEPARTMENT_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string? DepartmentGuid { get; set; }

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

    [ForeignKey("DepartmentGuid")]
    [InverseProperty("Employment")]
    public virtual Department? Department { get; set; }

    [ForeignKey("EmployeeGuid")]
    [InverseProperty("Employment")]
    public virtual Employee Employee { get; set; } = null!;

    [InverseProperty("Employment")]
    public virtual ICollection<EmploymentPay> EmploymentPay { get; set; } = new List<EmploymentPay>();

    [ForeignKey("JobGuid")]
    [InverseProperty("Employment")]
    public virtual Job Job { get; set; } = null!;

    [InverseProperty("Employment")]
    public virtual ICollection<Manager> Manager { get; set; } = new List<Manager>();
}

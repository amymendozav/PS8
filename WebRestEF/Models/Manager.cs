using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("MANAGER")]
public partial class Manager
{
    [Key]
    [Column("MANAGER_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string ManagerGuid { get; set; } = null!;

    [Column("EMPLOYMENT_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string EmploymentGuid { get; set; } = null!;

    [Column("DEPARTMENT_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string DepartmentGuid { get; set; } = null!;

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
    [InverseProperty("Manager")]
    public virtual Department Department { get; set; } = null!;

    [ForeignKey("EmploymentGuid")]
    [InverseProperty("Manager")]
    public virtual Employment Employment { get; set; } = null!;
}

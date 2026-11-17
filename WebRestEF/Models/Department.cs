using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("DEPARTMENT")]
public partial class Department
{
    [Key]
    [Column("DEPARTMENT_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string DepartmentGuid { get; set; } = null!;

    [Column("DEPARTMENT_NAME")]
    [StringLength(30)]
    [Unicode(false)]
    public string DepartmentName { get; set; } = null!;

    [Column("LOCATION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string LocationGuid { get; set; } = null!;

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

    [InverseProperty("Department")]
    public virtual ICollection<Employment> Employment { get; set; } = new List<Employment>();

    [ForeignKey("LocationGuid")]
    [InverseProperty("Department")]
    public virtual MidtermLocation Location { get; set; } = null!;

    [InverseProperty("Department")]
    public virtual ICollection<Manager> Manager { get; set; } = new List<Manager>();
}

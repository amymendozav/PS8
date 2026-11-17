using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("EMPLOYEE")]
public partial class Employee
{
    [Key]
    [Column("EMPLOYEE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string EmployeeGuid { get; set; } = null!;

    [Column("FIRST_NAME")]
    [StringLength(20)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("LAST_NAME")]
    [StringLength(25)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("EMAIL")]
    [StringLength(25)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("PHONE_NUMBER")]
    [StringLength(20)]
    [Unicode(false)]
    public string PhoneNumber { get; set; } = null!;

    [Column("HIRE_DATE", TypeName = "DATE")]
    public DateTime HireDate { get; set; }

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

    [InverseProperty("Employee")]
    public virtual ICollection<Employment> Employment { get; set; } = new List<Employment>();
}

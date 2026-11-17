using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("INSTRUCTOR")]
public partial class Instructor
{
    [Key]
    [Column("INSTRUCTOR_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string InstructorGuid { get; set; } = null!;

    [Column("SALUTATION")]
    [StringLength(5)]
    [Unicode(false)]
    public string Salutation { get; set; } = null!;

    [Column("FIRST_NAME")]
    [StringLength(25)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("LAST_NAME")]
    [StringLength(25)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("PHONE")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Phone { get; set; }

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

    [InverseProperty("Instructor")]
    public virtual ICollection<InstructorAddress> InstructorAddress { get; set; } = new List<InstructorAddress>();

    [InverseProperty("Instructor")]
    public virtual ICollection<Section> Section { get; set; } = new List<Section>();
}

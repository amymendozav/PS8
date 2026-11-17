using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("REGION")]
public partial class Region
{
    [Key]
    [Column("REGION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string RegionGuid { get; set; } = null!;

    [Column("REGION_NAME")]
    [StringLength(25)]
    [Unicode(false)]
    public string RegionName { get; set; } = null!;

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

    [InverseProperty("Region")]
    public virtual ICollection<Country> Country { get; set; } = new List<Country>();
}

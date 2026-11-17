using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("COUNTRY")]
public partial class Country
{
    [Key]
    [Column("COUNTRY_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string CountryGuid { get; set; } = null!;

    [Column("COUNTRY_ID")]
    [StringLength(2)]
    [Unicode(false)]
    public string CountryId { get; set; } = null!;

    [Column("COUNTRY_NAME")]
    [StringLength(40)]
    [Unicode(false)]
    public string CountryName { get; set; } = null!;

    [Column("REGION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string RegionGuid { get; set; } = null!;

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

    [InverseProperty("Country")]
    public virtual ICollection<MidtermLocation> MidtermLocation { get; set; } = new List<MidtermLocation>();

    [ForeignKey("RegionGuid")]
    [InverseProperty("Country")]
    public virtual Region Region { get; set; } = null!;
}

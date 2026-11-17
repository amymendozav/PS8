using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("MIDTERM_LOCATION")]
public partial class MidtermLocation
{
    [Key]
    [Column("LOCATION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string LocationGuid { get; set; } = null!;

    [Column("STREET_ADDRESS")]
    [StringLength(40)]
    [Unicode(false)]
    public string? StreetAddress { get; set; }

    [Column("POSTAL_CODE")]
    [StringLength(12)]
    [Unicode(false)]
    public string? PostalCode { get; set; }

    [Column("CITY")]
    [StringLength(30)]
    [Unicode(false)]
    public string City { get; set; } = null!;

    [Column("COUNTRY_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string CountryGuid { get; set; } = null!;

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

    [Column("STATE_PROVINCE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string? StateProvinceGuid { get; set; }

    [ForeignKey("CountryGuid")]
    [InverseProperty("MidtermLocation")]
    public virtual Country Country { get; set; } = null!;

    [InverseProperty("Location")]
    public virtual ICollection<Department> Department { get; set; } = new List<Department>();

    [ForeignKey("StateProvinceGuid")]
    [InverseProperty("MidtermLocation")]
    public virtual StateProvince? StateProvince { get; set; }
}

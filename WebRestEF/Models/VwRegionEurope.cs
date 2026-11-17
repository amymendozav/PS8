using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Keyless]
public partial class VwRegionEurope
{
    [Column("REGION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string RegionGuid { get; set; } = null!;

    [Column("REGION_NAME")]
    [StringLength(25)]
    [Unicode(false)]
    public string RegionName { get; set; } = null!;

    [Column("COUNTRY_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string CountryGuid { get; set; } = null!;

    [Column("COUNTRY_NAME")]
    [StringLength(40)]
    [Unicode(false)]
    public string CountryName { get; set; } = null!;

    [Column("LOCATION_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string LocationGuid { get; set; } = null!;

    [Column("CITY")]
    [StringLength(30)]
    [Unicode(false)]
    public string City { get; set; } = null!;
}

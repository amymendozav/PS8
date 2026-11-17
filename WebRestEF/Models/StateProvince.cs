using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Table("STATE_PROVINCE")]
public partial class StateProvince
{
    [Key]
    [Column("STATE_PROVINCE_GUID")]
    [StringLength(32)]
    [Unicode(false)]
    public string StateProvinceGuid { get; set; } = null!;

    [Column("STATE_PROVINCE_NAME")]
    [StringLength(25)]
    [Unicode(false)]
    public string StateProvinceName { get; set; } = null!;

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

    [InverseProperty("StateProvince")]
    public virtual ICollection<MidtermLocation> MidtermLocation { get; set; } = new List<MidtermLocation>();
}

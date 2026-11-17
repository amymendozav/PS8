using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebRest.EF.Models;

[Index("UserId", Name = "IX_AspNetUserPasskeys_UserId")]
public partial class AspNetUserPasskeys
{
    [Key]
    [MaxLength(1024)]
    public byte[] CredentialId { get; set; } = null!;

    public string UserId { get; set; } = null!;

    [Column(TypeName = "JSON")]
    public string Data { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("AspNetUserPasskeys")]
    public virtual AspNetUsers User { get; set; } = null!;
}

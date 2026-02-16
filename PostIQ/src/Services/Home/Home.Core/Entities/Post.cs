using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Home.Core.Entities;

[Table("Posts", Schema = "Home")]
public partial class Post
{
    [Key]
    public long Id { get; set; }

    public long UserId { get; set; }

    public long RepoDetailsId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Source { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? RepoUrl { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Key { get; set; }

    [Unicode(false)]
    public string? Value { get; set; }

    public int? Ordered { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public bool IsActive { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime PostedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    public long? UpdatedBy { get; set; }
}

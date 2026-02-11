using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Published.Core.Entities;

[Table("Repos", Schema = "Published")]
public partial class Repo
{
    [Key]
    public long RepoId { get; set; }

    public long JobId { get; set; }

    public long PublishedId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Source { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string RepoUrl { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string Status { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public string IsActive { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime PostedOn { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    public long? UpdatedBy { get; set; }

    [ForeignKey("JobId")]
    [InverseProperty("Repos")]
    public virtual Job Job { get; set; } = null!;

    [InverseProperty("Repo")]
    public virtual ICollection<RepoDetail> RepoDetails { get; set; } = new List<RepoDetail>();
}

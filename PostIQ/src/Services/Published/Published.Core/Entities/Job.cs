using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Published.Core.Entities;

[Table("Job", Schema = "Published")]
public partial class Job
{
    [Key]
    public long JobId { get; set; }

    public long PublishedId { get; set; }

    public long UserId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Source { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string BaseUrl { get; set; } = null!;

    [StringLength(100)]
    [Unicode(false)]
    public bool IsActive { get; set; } = true;

    [Column(TypeName = "datetime")]
    public DateTime CreatedOn { get; set; }

    public long CreatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedOn { get; set; }

    public long? UpdatedBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ExecutationStartTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NextExecutionTime { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Status { get; set; }

    [InverseProperty("Job")]
    public virtual ICollection<Repo> Repos { get; set; } = new List<Repo>();
}

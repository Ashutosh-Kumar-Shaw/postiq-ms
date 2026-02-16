using MediatR;
using Microsoft.EntityFrameworkCore;
using PostIQ.Core.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Home.Application.Commands
{
    /// <summary>
    /// Command to upsert a batch of posts.
    /// Models is an init-only collection and defaults to empty to avoid null checks.
    /// </summary>
    public class MergePostCommand : IRequest<SingleResponse<bool>>
    {
        public List<MergePostModel> Models { get; set; }
    }

    public class MergePostModel
    {
        public long Id { get; init; }

        public long UserId { get; init; }

        public long RepoDetailsId { get; init; }

        public string? Source { get; init; }

        public string? RepoUrl { get; init; }

        public string? Key { get; init; }

        public string? Value { get; init; }

        public int? Ordered { get; init; }

        public string IsActive { get; init; } = null!;

        public DateTime PostedOn { get; init; }

        public DateTime CreatedOn { get; init; }

        public long CreatedBy { get; init; }
    }
}

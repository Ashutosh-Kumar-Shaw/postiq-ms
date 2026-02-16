using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Published.Application.Response
{
    public record BatchRepoDetailsRes
    {
        public long UserId { get; init; }

        public long RepoDetailsId { get; init; }

        public string? Source { get; init; }

        public string? RepoUrl { get; init; }

        public string? Key { get; init; }

        public string? Value { get; init; }

        public int? Ordered { get; init; }

        public string IsActive { get; init; } = null!;

        public DateTime PostedOn { get; init; }

    }
}

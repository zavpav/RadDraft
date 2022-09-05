using Rad.Domain.Docs.Grbs.KuDetail;
using Rad.Domain.Docs.Grbs.ToRezerv;
using Rad.Domain.Docs.Grbs.ToPbs;

namespace Rad.Db;

/// <summary> Контекст работы с БР </summary>
public class GrbsDbContext : DbContext
{
    public GrbsDbContext(DbContextOptions<GrbsDbContext> options) : base(options)
    {
    }


    public DbSet<DocKuDetail> KuDetails { get; set; } = null!;

    public DbSet<DocKuDetailRow> KuDetailRows { get; set; } = null!;

    public DbSet<DocToRezerv> ToRezerv { get; set; } = null!;

    public DbSet<DocToRezervRow> ToRezervRows { get; set; } = null!;

    public DbSet<DocToPbs> ToPbs { get; set; } = null!;

    public DbSet<DocToPbsRow> ToPbsRows { get; set; } = null!;
}

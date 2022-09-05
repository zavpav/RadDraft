using Rad.Domain.Brs;

namespace Rad.Db;

/// <summary> Контекст работы с БР </summary>
public class BrDbContext : DbContext
{
    public BrDbContext(DbContextOptions<BrDbContext> options) : base(options)
    {
    }

    /// <summary> БР </summary>
    public DbSet<Br> Brs { get; set; } = null!;

    /// <summary> Структура БР </summary>
    public DbSet<BrStructRow> StructRows { get; set; } = null!;

    /// <summary> Суммы БР </summary>
    public DbSet<BrSumRow> BrSumRows { get; set; } = null!;

}

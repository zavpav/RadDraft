using Rad.Db;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace Rad.Domain.Brs;

public interface IBrRepository
{
}

public class BrRepository : IBrRepository
{
    private readonly IDbContextFactory<BrDbContext> _dbContextFactory;

    public BrRepository(IDbContextFactory<BrDbContext> dbContextFactory)
    {
        this._dbContextFactory = dbContextFactory;
    }

    private ConcurrentDictionary<BrKey, Br> _brCache = new();

    public async ValueTask<Br> GetBr(long orgId, int year, EnumBrType brType)
    {
        var brKey = new BrKey { OrgId = orgId, BrType = brType, Year = year };
        if (_brCache.TryGetValue(brKey, out Br? br))
            return br;

        using var db = this._dbContextFactory.CreateDbContext();
        
        var br1 = await db.Brs
            .Where(x => x.OrgSid == orgId && x.Year == year && x.BrType == brType)
            .Include(x => x.Rows)
            .ThenInclude(x => x.Sums)
            .FirstAsync();

        this._brCache.TryAdd(brKey, br1);

        return br1;
    }


    /// <summary> Ключ хранения БР </summary>
    private struct BrKey: IEqualityComparer<BrKey>
    {
        /// <summary> Организация </summary>
        public long OrgId { get; set; }

        /// <summary> Тип БР </summary>
        public EnumBrType BrType { get; set; }

        /// <summary> Рабочий год </summary>
        public int Year { get; set; }

        public bool Equals(BrKey x, BrKey y)
        {
            return x.OrgId == y.OrgId 
                && x.BrType == y.BrType 
                && x.Year == y.Year;
        }

        public int GetHashCode([DisallowNull] BrKey obj)
        {
            return obj.OrgId.GetHashCode() ^ obj.BrType.GetHashCode() ^ obj.Year.GetHashCode();
        }
    }

}


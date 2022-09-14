using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        public readonly NZWalksDbContext _nZWalksDbContext;
        public WalkDifficultyRepository(NZWalksDbContext nZWalksDbContext)
        {
            _nZWalksDbContext = nZWalksDbContext;
        }
        public async Task<WalkDifficulty> AddWalkDifficultyAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            await _nZWalksDbContext.WalkDifficulty.AddAsync(walkDifficulty);
            await _nZWalksDbContext.SaveChangesAsync();

            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteWalkDifficultyAsync(Guid id)
        {
            var walkDifficultyDomain = await _nZWalksDbContext.WalkDifficulty.FindAsync(id);

            if (walkDifficultyDomain == null)
            {
                return null;
            }

            _nZWalksDbContext.WalkDifficulty.Remove(walkDifficultyDomain);
            await _nZWalksDbContext.SaveChangesAsync();


            return walkDifficultyDomain;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllWalkDifficultyAsync()
        {
            return await _nZWalksDbContext.WalkDifficulty.ToListAsync();

        }

        public async Task<WalkDifficulty> GetSingleWalkDifficultyAsync(Guid id)
        {
            var walkDifficulty = await _nZWalksDbContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);

            if (walkDifficulty == null)
            {
                return null;
            }

            return walkDifficulty;
        }

        public async Task<WalkDifficulty> UpdateWalkDifficultyAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await _nZWalksDbContext.WalkDifficulty.FindAsync(id);

            if (existingWalkDifficulty != null)
            {
                existingWalkDifficulty.Code = walkDifficulty.Code;

                await _nZWalksDbContext.SaveChangesAsync();

                return existingWalkDifficulty;
            }

            return null;




        }
    }
}

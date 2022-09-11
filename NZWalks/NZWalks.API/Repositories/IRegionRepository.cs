using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegionsAsync();

        Task<Region> GetSingleRegionAsync(Guid id);

        Task<Region> AddRegionAsync(Region region);
    }
}


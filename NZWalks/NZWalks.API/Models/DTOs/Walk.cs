using NZWalks.API.Models.Domain;

namespace NZWalks.API.Models.DTOs
{
    public class Walk
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double Length { get; set; }

        public Guid RegionId { get; set; }

        public Guid WalkDifficultyId { get; set; }

        //Navigation props

        public WalkDifficulty WalkDifficulty { get; set; }

        public Region Region { get; set; }
    }
}

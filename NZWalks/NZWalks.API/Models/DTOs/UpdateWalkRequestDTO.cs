namespace NZWalks.API.Models.DTOs
{
    public class UpdateWalkRequestDTO
    {
        public string Name { get; set; }

        public double Length { get; set; }

        public Guid RegionId { get; set; }

        public Guid WalkDifficultyId { get; set; }
    }
}

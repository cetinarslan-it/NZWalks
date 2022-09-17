using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;
using System.Data;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class WalkDifficultyController : Controller
    {
        public readonly IWalkDifficultyRepository _walkDifficultyRepository;

        public readonly IMapper _mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            _walkDifficultyRepository = walkDifficultyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllWalkDifficultyAsync()
        {
            var result = await _walkDifficultyRepository.GetAllWalkDifficultyAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetOneWalkDifficultyAsync")]
        [Authorize(Roles = "reader")]

        public async Task<IActionResult> GetSingleWalkDifficultAsync(Guid id)
        {
            var walkDifficult = await _walkDifficultyRepository.GetSingleWalkDifficultyAsync(id);

            if (walkDifficult == null)
            {
                return NotFound();
            }

            var walkDifficultyDTO = _mapper.Map<Models.DTOs.WalkDifficulty>(walkDifficult);

            return Ok(walkDifficultyDTO);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddWalkDifficultAsync([FromBody] Models.DTOs.WalkDifficulty walkDifficulty)
        {
            var walkDifficultyDomain = _mapper.Map<Models.Domain.WalkDifficulty>(walkDifficulty);

            await _walkDifficultyRepository.AddWalkDifficultyAsync(walkDifficultyDomain);

            var walkDifficultyDTO = _mapper.Map<Models.DTOs.WalkDifficulty>(walkDifficulty);

            return CreatedAtAction("GetOneWalkDifficultyAsync", new { id = walkDifficultyDTO.Id }, walkDifficultyDTO);

        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> UpdateWalkDifficultyAsync([FromRoute] Guid id, [FromBody] Models.DTOs.WalkDifficulty walkDifficulty)
        {


            var walkDifficultyDomain = await _walkDifficultyRepository.GetSingleWalkDifficultyAsync(id);

            if (walkDifficultyDomain == null)
            {
                return NotFound();
            }

            walkDifficultyDomain.Code = walkDifficulty.Code;

            await _walkDifficultyRepository.UpdateWalkDifficultyAsync(id, walkDifficultyDomain);

            var walkDifficultyDTO = _mapper.Map<Models.DTOs.WalkDifficulty>(walkDifficulty);

            return Ok(walkDifficultyDTO);

        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]

        public async Task<IActionResult> DeleteWalkDifficultyAsync([FromRoute] Guid id)
        {
            var walkDifficultyDomain = await _walkDifficultyRepository.DeleteWalkDifficultyAsync(id);

            if (walkDifficultyDomain == null)
            {
                return NotFound();
            }

            var walkDifficultyDTO = _mapper.Map<Models.DTOs.WalkDifficulty>(walkDifficultyDomain);

            return Ok(walkDifficultyDTO);

        }
    }
}




using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;
using AutoMapper;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {

        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetAllAsync();

            var regionsDTO = _mapper.Map<List<Models.DTOs.Region>>(regions);

            return Ok(regionsDTO);
        }
    }
}

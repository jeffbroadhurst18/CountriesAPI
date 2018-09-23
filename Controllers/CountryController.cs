using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CountriesAPI.Data;
using Microsoft.AspNetCore.Mvc;


namespace CountriesAPI.Controllers
{
	[Produces("application/json")]
    [Route("api/country")]
	[ApiController]
    public class CountryController : ControllerBase
    {
		private readonly ICountriesRepo _repo;
		private readonly IMapper _mapper;

		public CountryController(ICountriesRepo countriesRepo, IMapper mapper)
		{
			_repo = countriesRepo;
			_mapper = mapper;
		}

		[HttpGet("{name}")]
		public async Task<IActionResult> Get(string name) 
		{
			try
			{
				var countries = await _repo.GetCountriesByName(name);

				if (countries == null) return NotFound($"Country {name} was not found");

				var mapped = _mapper.Map<IEnumerable<CountryModel>>(countries);
				return Ok(mapped);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpGet("")]
		public async Task<IActionResult> Get([FromQuery] Filter filter)
		{ 
			try
			{
				BaseCountry[] countries;
				if (filter.maxpopulation == 0 && filter.minpopulation == 0)
				{
					countries = await _repo.GetCountriesByName(filter.name);
				}
				else
				{
					countries = await _repo.GetCountriesByPop(filter);
				}
				

				if (countries == null) return NotFound($"Country {filter.name} was not found");

 				var mapped =_mapper.Map<IEnumerable<CountryModel>>(countries);
				return Ok(mapped);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		[HttpGet("all")]
		public async Task<IActionResult> Get()
		{
			try
			{
				var countries = await _repo.GetCountries();

				if (countries == null) return NotFound($"Countries were not found");

				var mapped = _mapper.Map<IEnumerable<CountryModel>>(countries);
				return Ok(mapped);
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		
	}
}
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CountriesAPI.Data
{
	public class CountriesRepo : ICountriesRepo
	{
		private readonly IConfiguration _config;
		private readonly string url;
		private static readonly HttpClient client = new HttpClient();

		public CountriesRepo(IConfiguration config)
		{
			_config = config;
			url = _config["Connection:BaseURL"];
		}

		public async Task<BaseCountry[]> GetCountriesByName(string name)
		{
			var json = await client.GetStringAsync(url + "/name/"+name);
			BaseCountry[] countryList = JsonConvert.DeserializeObject<BaseCountry[]>(json);
			BaseCountry[] countries = countryList.Where(c => c.name.ToLower().Contains(name.ToLower())).OrderBy(c => c.name).ToArray();

			return countries;
		}

		public async Task<BaseCountry[]> GetCountries()
		{
			var json = await client.GetStringAsync(url + "/all");
			BaseCountry[] countryList = JsonConvert.DeserializeObject<BaseCountry[]>(json);
			BaseCountry[] countries = countryList.OrderBy(c => c.name).ToArray();

			return countries;
		}

		public async Task<BaseCountry[]> GetCountriesByPop(Filter filter)
		{
			var json = await client.GetStringAsync(url + "/all");
			BaseCountry[] countryList = JsonConvert.DeserializeObject<BaseCountry[]>(json);
			BaseCountry[] countries = countryList.Where(p => p.population >= (filter.minpopulation*1000000) && (p.population <= (filter.maxpopulation*1000000)))
				.OrderBy(c => c.population).ToArray();
			return countries;
		}
	}
}

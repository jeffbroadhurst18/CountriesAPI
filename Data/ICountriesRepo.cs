using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountriesAPI.Data
{
    public interface ICountriesRepo
    {
		Task<BaseCountry[]> GetCountriesByName(string name);
		Task<BaseCountry[]> GetCountries();
		Task<BaseCountry[]> GetCountriesByPop(Filter filter);
	}
}

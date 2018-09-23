using AutoMapper;

namespace CountriesAPI.Data
{
	public class CountryMappingProfile : Profile
    {
		public CountryMappingProfile()
		{
			CreateMap<BaseCountry, CountryModel>().ForMember(r => r.Name, c => c.MapFrom(m => m.name))
			.ForMember(r => r.Capital, c => c.MapFrom(m => m.capital))
			.ForMember(r => r.Population, c => c.MapFrom(m => m.population/1000000))
			.ForMember(r => r.Region, c => c.MapFrom(m => m.region))
			.ForMember(r => r.Subregion, c => c.MapFrom(m => m.subregion));
		}
    }
}

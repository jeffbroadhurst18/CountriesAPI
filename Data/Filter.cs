using Newtonsoft.Json;

namespace CountriesAPI.Data
{

	public class Filter
	{
		[JsonProperty("name")]
		public string name { get; set; }
		[JsonProperty("capital")]
		public string capital { get; set; }
		[JsonProperty("minpopulation")]
		public int minpopulation { get; set; }
		[JsonProperty("maxpopulation")]
		public int maxpopulation { get; set; }
		[JsonProperty("region")]
		public string region { get; set; }
		[JsonProperty("subregion")]
		public string subregion {get; set;}
    }
}

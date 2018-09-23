using CountriesAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace CountriesAPI
{
	public class Startup
    {
		public Startup(IConfiguration configuration, IHostingEnvironment env)
		{
			_config = configuration;
			_env = env;
		}

		private IConfiguration _config;
		private readonly IHostingEnvironment _env;

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<ICountriesRepo, CountriesRepo>(); //scope = single request			}
			services.AddSingleton(_config);
			services.AddAutoMapper();
			services.AddMvc();

		}
			// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
			public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

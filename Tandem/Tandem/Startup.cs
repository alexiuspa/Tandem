using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Tandem.Models;
using Tandem.DAL;
using FluentValidation;
using FluentValidation.AspNetCore;
using AutoMapper;


namespace Tandem
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddOptions();

			services.Configure<CosmosDBConfiguration>(Configuration.GetSection("CosmosDConfiguration"));

			services.AddAutoMapper( typeof(Startup));


			services.AddScoped< IRepository<Patient> , CosmosDBRepo<Patient> >();

			services.AddSwaggerGen(sw =>
			{

				{
					sw.SwaggerDoc("v1", new OpenApiInfo { Title = "Tandem  API", Version = "V1", Description = "Tandem POC - Backend API's" });
				};

				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				sw.IncludeXmlComments(xmlPath);

			});


			services.AddTransient<IValidator<Patient> ,  PatientValidator>();

			services.AddMvc().AddFluentValidation();

			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});


			app.UseSwagger();


			app.UseSwaggerUI(ui =>
			{
				ui.SwaggerEndpoint("../v1/swagger.json", "Tandem API - Developer's Guide");
				ui.RoutePrefix = "swagger/v1";

			}

				);

		}
	}
}

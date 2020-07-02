using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Tandem;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace UnitTestCoverage
{
	[TestClass]
	public class Controller
	{


		private  static HttpClient tstClient;


		protected virtual void InitializeServices(IServiceCollection services)
		{
			var startupAssembly = typeof(Startup).GetTypeInfo().Assembly;

			var manager = new ApplicationPartManager
			{
				ApplicationParts =
				{
					new AssemblyPart(startupAssembly)
				},
				FeatureProviders =
				{
					new ControllerFeatureProvider(),
					new ViewComponentFeatureProvider()
				}
			};

			services.AddSingleton(manager);
		}

		[TestInitialize]

		public void Init()
		{


			var configurationBuilder = new ConfigurationBuilder()
							.AddJsonFile("appsettings.json");
			var webHostBuilder = new WebHostBuilder()
				//	.UseContentRoot(contentRoot)
					.ConfigureServices(InitializeServices)
					.UseConfiguration(configurationBuilder.Build())
					.UseEnvironment("Development")
					.UseStartup(typeof(Startup));

			// Create instance of test server
			var server = new TestServer(webHostBuilder);

			tstClient = server.CreateClient();
			

		
		
		}




		[TestMethod]
		public void TestMethod1()
		{


			//Arrange
			var req = new HttpRequestMessage(new HttpMethod("GET"), "api/v1/patient/al@gmail.com");

			//Act

			var resp =tstClient.SendAsync(req).Result;



			//Assert

			

		}
	}
}

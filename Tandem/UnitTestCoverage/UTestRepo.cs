using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography.Xml;
using System.ServiceModel;
using Tandem.DAL;
using Tandem.Models;



namespace UnitTestCoverage
{

	[TestClass]
	public class UTestRepo
	{

		IOptions<CosmosDBConfiguration> connProperties;

		CosmosDBRepo<Patient> client;

	   [TestInitialize]
		public void Init()
		{

			 connProperties = Options.Create(new  CosmosDBConfiguration
			{
				Account = "https://tandemdb.documents.azure.com:443/",
				ContainerName = "Patients",
				DatabasName = "TandemDB",
				Key = "KKO95GszCRb4w0kDEGaaBVoscVP61aoxGnTnFnPxGuxGVuZYyIzD3QPRgw8xQEfW4PfecOxmB8Yce30tRy6ceA=="



			 });


			client = new CosmosDBRepo<Patient>(connProperties);
		}



		[TestMethod]
		public void Test_Comos_Connection()
		{

			  client = new CosmosDBRepo<Patient>(connProperties);



			Assert.IsNotNull(client);

				
		
		
		}


		[TestMethod]
		public   void Add_Patient_To_Containter()
		{

			Patient oPatient = new Patient() {


				EmailAddress = "alexiuspa@yahoo.com",
				FirstName = "Alex",
				LastName = "Iuspa",
				PhoneNumber = "555-555-1234",
				id = Guid.NewGuid().ToString()	 
			 
			
			};



			var entity = client.Add(  oPatient).Result;

			Assert.IsNotNull(entity);

		}


		[TestMethod]
		public void  Update_Patient_Phone()

		{
			string myid = "7a54bb91-e3ac-4aa7-8ea9-11ad07d9ada3";


			Patient oPatient = new Patient()
			{


				EmailAddress = "alexiuspa@yahoo.com",
				FirstName = "Alex",
				LastName = "Iuspa",
				PhoneNumber = "111-555-1234",
				id = myid


			};



		   var entity  =     	client.Update(oPatient).Result;

		}
	}
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Options;
using Tandem.Models;
using Microsoft.Azure.Cosmos;
using System.Security.Permissions;
using System.Threading.Tasks;
using Newtonsoft.Json.Schema;
using System.Linq;

namespace Tandem.DAL
{
	public class CosmosDBRepo<T> : IRepository<T> where T: class
	{

		private CosmosClient dbClient = null;
		private Container container = null;

		public CosmosDBRepo( IOptions<CosmosDBConfiguration> options )
		{

			try
			{


				dbClient = new CosmosClient(options.Value.Account, options.Value.Key);

				dbClient.CreateDatabaseIfNotExistsAsync(options.Value.DatabaseName);

				container = dbClient.GetContainer(options.Value.DatabaseName, options.Value.ContainerName);

			}
			catch (Exception err)
			{ 
			
			
			   // Log error locally and application insight
			}



			
		}



		public  async  Task<T> Add(T entity )
		{

		     var response =   await	container.CreateItemAsync<T>(entity);

			return entity;


		}

		public async System.Threading.Tasks.Task<T> GetAll(string id)
		{


			var sqlQueryText = $"SELECT * FROM c WHERE c.EmailAddress = '{id}'";

		 

			QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
			FeedIterator<T> queryResultSetIterator =  container.GetItemQueryIterator<T>(queryDefinition);



			if  (queryResultSetIterator.HasMoreResults)
			{
				FeedResponse<T> currentResultSet = await queryResultSetIterator.ReadNextAsync();
				var items = currentResultSet.ToList<T>();

				return items[0];

			}

			return null;


		}

		public  async Task<T> Update(T entity)
		{
			var response = await container.UpsertItemAsync<T>(entity);

			return entity;


		}
	}
}

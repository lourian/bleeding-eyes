using System;
using Cinema.Models;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Cinema.Extensions;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Cinema.Repositories.Filters;
using Cinema.Models.Requests;

namespace Cinema.Repositories
{
    public class MovieRepository : IRepository<Movie>
    {
        private readonly string _connectionString;

        public MovieRepository(IConfiguration configuration)
        {
            _connectionString = configuration["AppSettings:PoolConnection"];
        }

        public async Task Add(IRequest request)
        {
            var movieRequest = request as MovieRequest;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var result = connection.Execute("insert into [dbo].[Movie] (Name, Description) values(@name, @description)", 
                        new { name = movieRequest.Name, description = movieRequest.Description});
                }
            }
            catch (Exception)
            {

            }
        }

        public async Task<Movie[]> GetByFilter(IFilter filter)
        {
            var movieFilter = filter as EntityFilter;
            var movies = new List<Movie>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var query = new CommandDefinition("select Id, Name from [dbo].[Movie] where Id = @EntityId", movieFilter);
                    var result = await connection.QueryAsync<Movie>(query);
                    if (!result.NullOrEmpty())
                    {
                        movies = result.ToList();
                    }
                }
            }
            catch (Exception)
            {

            }
            return movies.ToArray();
        }

        public async Task<Movie[]> GetAll()
        {
            var movies = new List<Movie>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var query = new CommandDefinition("select Id, Name, Description from [dbo].[Movie]");
                    var result = await connection.QueryAsync<Movie>(query);
                    if(!result.NullOrEmpty())
                    {
                        movies = result.ToList();
                    }
                }
            }
            catch (Exception)
            {

            }
            return movies.ToArray();
        }

        public async Task Remove(int entityId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var result = connection.Execute("delete from [dbo].[Movie] where Id = @id",
                        new { id = entityId});
                }
            }
            catch (Exception)
            {

            }
        }
    }
}

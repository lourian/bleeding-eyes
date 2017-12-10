using System;
using System.Threading.Tasks;
using Cinema.Models.Requests;
using Cinema.Repositories.Filters;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using Cinema.Extensions;
using System.Linq;

namespace Cinema.Repositories
{
    public class CinemaRepository : IRepository<Models.Cinema>
    {
        private readonly string _connectionString;

        public CinemaRepository(IConfiguration configuration)
        {
            _connectionString = configuration["AppSettings:PoolConnection"];
        }

        public async Task Add(IRequest request)
        {
            var cinemaRequest = request as CinemaRequest;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var result = connection.Execute("insert into [dbo].[Cinema] (Name) values(@Name)",
                        cinemaRequest);
                }
            }
            catch (Exception)
            {

            }
        }

        public async Task<Models.Cinema[]> GetAll()
        {
            var cinemas = new List<Models.Cinema>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var query = new CommandDefinition("select Id, Name from [dbo].[Cinema]");
                    var result = await connection.QueryAsync<Models.Cinema>(query);
                    if (!result.NullOrEmpty())
                    {
                        cinemas = result.ToList();
                    }
                }
            }
            catch (Exception)
            {

            }
            return cinemas.ToArray();
        }

        public async Task<Models.Cinema[]> GetByFilter(IFilter filter)
        {
            var cinemaFilter = filter as EntityFilter;
            var cinemas = new List<Models.Cinema>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var query = new CommandDefinition("select Id, Name from [dbo].[Cinema] where Id = @EntityId", cinemaFilter);
                    var result = await connection.QueryAsync<Models.Cinema>(query);
                    if (!result.NullOrEmpty())
                    {
                        cinemas = result.ToList();
                    }
                }
            }
            catch (Exception)
            {

            }
            return cinemas.ToArray();
        }

        public async Task Remove(int entityId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var result = connection.Execute("delete from [dbo].[Cinema] where Id = @entityId",
                        entityId);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}

using Cinema.Models;
using System;
using Cinema.Models.Requests;
using Cinema.Repositories.Filters;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Collections.Generic;
using Cinema.Extensions;
using System.Linq;

namespace Cinema.Repositories
{
    public class MovieShowRepository : IRepository<MovieShow>
    {
        private readonly string _connectionString;

        public MovieShowRepository(IConfiguration configuration)
        {
            _connectionString = configuration["AppSettings:PoolConnection"];
        }

        public async Task Add(IRequest request)
        {
            var movieShowRequest = request as MovieShowRequest;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var result = connection.Execute("insert into [dbo].[MovieShow] (CinemaId, MovieId, Date) values(@CinemaId, @MovieId, @Date)",
                        movieShowRequest);
                }
            }
            catch (Exception)
            {

            }
        }

        public async Task<MovieShow[]> GetAll()
        {
            var movieShows = new List<MovieShow>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var query = new CommandDefinition("select Id, CinemaId, MovieId, Date from [dbo].[MovieShow]");
                    var result = await connection.QueryAsync<MovieShow>(query);
                    if (!result.NullOrEmpty())
                    {
                        movieShows = result.ToList();
                    }
                }
            }
            catch (Exception)
            {

            }
            return movieShows.ToArray();
        }

        public async Task<MovieShow[]> GetByFilter(IFilter filter)
        {
            var commandDefinition = new CommandDefinition();
            if (filter is MovieShowFilter)
            {
                var movieShowFilter = filter as MovieShowFilter;
                commandDefinition = new CommandDefinition(@"select Id, CinemaId, MovieId, Date from [dbo].[MovieShow] 
                            where CinemaId = @CinemaId and MovieId = @MovieId and cast(Date as DATE) = cast(@Date as DATE)", movieShowFilter);
            }
            if (filter is DateFilter)
            {
                var dateFilter = filter as DateFilter;
                commandDefinition = new CommandDefinition(@"select Id, CinemaId, MovieId, Date from [dbo].[MovieShow] 
                            where cast(Date as DATE) = cast(@Date as DATE)", dateFilter);
            }

            var movieShows = new List<MovieShow>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var result = await connection.QueryAsync<MovieShow>(commandDefinition);
                    if (!result.NullOrEmpty())
                    {
                        movieShows = result.ToList();
                    }
                }
            }
            catch (Exception)
            {

            }
            return movieShows.ToArray();
        }

        public async Task Remove(int entityId)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var result = connection.Execute("delete from [dbo].[MovieShow] where Id = @entityId",
                        entityId);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}

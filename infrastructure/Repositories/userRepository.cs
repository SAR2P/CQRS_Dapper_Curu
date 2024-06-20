using Dapper;
using Domain.Models;
using Domain.Repositories;
using System.Data;


namespace infrastructure.Repositories
{
    public class userRepository : IUserRepositories
    {

        #region constructor
        private readonly IDbConnection _dbConnection;
        public userRepository(IDbConnection dbConnection)
        {
           _dbConnection = dbConnection;
        }
        #endregion End Constructor


        public async Task AddUserAsync(UserClass user)
        {
            var sql = "insert into users(FullName,Age) values(@FullName,@Age)";

            await _dbConnection.ExecuteAsync(sql, new {FullName = user.FullName, Age = user.Age});

        }

        public async Task DeleteUserAsync(int id)
        {
            var sql = @"delete from users where Id=@Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }

       

        public async Task<IEnumerable<UserClass>> GetAllUSersAsync()
        {
            var sql = "select * from users";
            return await _dbConnection.QueryAsync<UserClass>(sql);
        }

        public async Task<UserClass> GetUserByIdAsync(int id)
        {
            var sql = "select Id,FullName,Age from users where Id =@id";
            return await _dbConnection.QueryFirstOrDefaultAsync<UserClass>(sql, new {id = id});
        }

        public async Task UpdateUserAsync(UserClass user)
        {
            var sql = @"update users set FullName= @FullName, Age=@Age where Id=@Id";
            await _dbConnection.ExecuteAsync(sql, user);
        }
    }
}

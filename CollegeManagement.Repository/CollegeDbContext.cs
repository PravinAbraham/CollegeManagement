using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CollegeManagement.Data
{
    public class CollegeDbContext
    {
        private readonly IConfiguration _configuration;
        public CollegeDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public IDbConnection CreateConnection()
            => new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
    }
}

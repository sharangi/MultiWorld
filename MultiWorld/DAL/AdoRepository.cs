using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MultiWorld.DAL
{
    public interface IAdoRepository
    {
        int? GetTransformerScore(Guid transformerId);
    }
    public class AdoRepository: IAdoRepository
    {
        private readonly IConfiguration _configuration;
        public AdoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int? GetTransformerScore(Guid transformerId)
        {
            int? score = null;
            string connectionString = _configuration["ConnectionStrings:DbConnectionString"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = "uspGetTransformerScore";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TransformerId", transformerId);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        score = reader.GetInt32(0);
                    }
                }
            }
            return score;
        }
    }
}

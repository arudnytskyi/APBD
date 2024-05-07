using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class TeamMemberRepository(string connectionString)
    {
        public TeamMember GetById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM TeamMember WHERE IdTeamMember = @IdTeamMember";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdTeamMember", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new TeamMember
                            {
                                IdTeamMember = (int)reader["IdTeamMember"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Email = (string)reader["Email"]
                            };
                        }

                        return null; 
                    }
                }
            }
        }

    }
}
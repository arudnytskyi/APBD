using System.Data.SqlClient;
using Task = WebApplication1.Models.Task;

namespace WebApplication1.Repositories{
    public class TaskRepository(string connectionString)
    {
        public List<Task> GetTasksByTeamMemberId(int teamMemberId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Task WHERE IdAssignedTo = @IdAssignedTo ORDER BY Deadline DESC";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdAssignedTo", teamMemberId);
                    using (var reader = command.ExecuteReader())
                    {
                        var tasks = new List<Task>();
                        while (reader.Read())
                        {
                            tasks.Add(new Task
                            {
                                IdTask = (int)reader["IdTask"],
                                Name = (string)reader["Name"],
                                Description = (string)reader["Description"],
                                Deadline = (DateTime)reader["Deadline"],
                                IdProject = (int)reader["IdProject"],
                                IdTaskType = (int)reader["IdTaskType"],
                                IdAssignedTo = (int)reader["IdAssignedTo"],
                                IdCreator = (int)reader["IdCreator"]
                            });
                        }
                        return tasks;
                    }
                }
            }
        }

        public List<Task> GetTasksCreatedByTeamMemberId(int teamMemberId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Task WHERE IdCreator = @IdCreator ORDER BY Deadline DESC";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdCreator", teamMemberId);
                    using (var reader = command.ExecuteReader())
                    {
                        var tasks = new List<Task>();
                        while (reader.Read())
                        {
                            tasks.Add(new Task
                            {
                                IdTask = (int)reader["IdTask"],
                                Name = (string)reader["Name"],
                                Description = (string)reader["Description"],
                                Deadline = (DateTime)reader["Deadline"],
                                IdProject = (int)reader["IdProject"],
                                IdTaskType = (int)reader["IdTaskType"],
                                IdAssignedTo = (int)reader["IdAssignedTo"],
                                IdCreator = (int)reader["IdCreator"]
                            });
                        }
                        return tasks;
                    }
                }
            }
        }

    }
}
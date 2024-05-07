using System.Data.SqlClient;

namespace WebApplication1.Repositories
{
    public class ProjectRepository
    {
        private readonly string _connectionString;

        public ProjectRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void DeleteProject(int projectId)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using var transaction = connection.BeginTransaction();
            try
            {
                var deleteProjectCommand = new SqlCommand("DELETE FROM Project WHERE IdProject = @IdProject", connection, transaction);
                deleteProjectCommand.Parameters.AddWithValue("@IdProject", projectId);
                deleteProjectCommand.ExecuteNonQuery();

                var deleteTasksCommand = new SqlCommand("DELETE FROM Task WHERE IdProject = @IdProject", connection, transaction);
                deleteTasksCommand.Parameters.AddWithValue("@IdProject", projectId);
                deleteTasksCommand.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw new Exception("Failed to delete project", ex);
            }
        }

    }
}
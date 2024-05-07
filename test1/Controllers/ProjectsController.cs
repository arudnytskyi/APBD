using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController(ProjectRepository projectRepository) : ControllerBase
    {
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            try
            {
                projectRepository.DeleteProject(id);
                return Ok(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }
    }
}
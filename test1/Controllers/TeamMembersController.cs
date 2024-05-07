using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMembersController(TeamMemberRepository teamMemberRepository, TaskRepository taskRepository)
        : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetTeamMember(int id)
        {
            try
            {
                var teamMember = teamMemberRepository.GetById(id);
                if (teamMember == null)
                {
                    return NotFound(); 
                }

                var tasksAssignedToMember = taskRepository.GetTasksByTeamMemberId(id);
                var tasksCreatedByMember = taskRepository.GetTasksCreatedByTeamMemberId(id);

                return Ok(new
                {
                    TeamMember = teamMember,
                    TasksAssignedToMember = tasksAssignedToMember,
                    TasksCreatedByMember = tasksCreatedByMember
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }

    }
}
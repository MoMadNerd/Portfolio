using API_Task_Manager.Data;
using API_Task_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Task_Manager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TasksController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/tasks
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Task>>> GetTasks()
    {
        var tasks = await _context.Tasks
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();

        return Ok(tasks);
    }

    // GET: api/tasks/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Task>> GetTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    // POST: api/tasks
    [HttpPost]
    public async Task<ActionResult<Task>> PostTask(TaskCreateRequest request)
    {
        var task = new Task
        {
            Title = request.Title,
            Description = request.Description,
            Priority = request.Priority,
            Completed = false,
            CreatedAt = DateTime.UtcNow
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
    }

    // PUT: api/tasks/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTask(int id, TaskUpdateRequest request)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        task.Title = request.Title;
        task.Description = request.Description;
        task.Priority = request.Priority;
        task.Completed = request.Completed;
        task.UpdatedAt = DateTime.UtcNow;

        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/tasks/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
        {
            return NotFound();
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

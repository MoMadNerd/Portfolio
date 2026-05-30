using API_Task_Manager.Models;

namespace API_Task_Manager.Services;

public interface ITaskRepository
{
    Task<IEnumerable<Task>> GetTasksAsync();
    Task<Task?> GetTaskByIdAsync(int id);
    Task<Task> CreateTaskAsync(TaskCreateRequest request);
    Task UpdateTaskAsync(int id, TaskUpdateRequest request);
    Task DeleteTaskAsync(int id);
}

public class TaskRepository : ITaskRepository
{
    private readonly ApplicationDbContext _context;

    public TaskRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Task>> GetTasksAsync()
    {
        return await _context.Tasks
            .OrderByDescending(t => t.CreatedAt)
            .ToListAsync();
    }

    public async Task<Task?> GetTaskByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<Task> CreateTaskAsync(TaskCreateRequest request)
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

        return task;
    }

    public async Task UpdateTaskAsync(int id, TaskUpdateRequest request)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task != null)
        {
            task.Title = request.Title;
            task.Description = request.Description;
            task.Priority = request.Priority;
            task.Completed = request.Completed;
            task.UpdatedAt = DateTime.UtcNow;

            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteTaskAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task != null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}

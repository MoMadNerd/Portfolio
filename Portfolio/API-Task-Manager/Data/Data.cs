using API_Task_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Task_Manager.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Task> Tasks => Set<Task>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Task>()
            .HasData(
                new Task { Id = 1, Title = "Learn .NET", Description = "Complete .NET tutorial", Priority = 3, Completed = true },
                new Task { Id = 2, Title = "Build API", Description = "Create REST API project", Priority = 5, Completed = false },
                new Task { Id = 3, Title = "Learn Docker", Description = "Containerize my applications", Priority = 4, Completed = false }
            );
    }
}

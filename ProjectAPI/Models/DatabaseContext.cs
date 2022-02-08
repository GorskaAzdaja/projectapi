using Microsoft.EntityFrameworkCore;

namespace ProjectAPI.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
            new Project
            {
                ProjectID = 1,
                Name = "First Project",
                Start_Date = DateTime.Now,
                Completion_Date = null,
                Project_Status = Project_Status.Active,
                Project_Priority = Project_Priority.High
            },

            new Project
            {
                ProjectID = 2,
                Name = "Second Project",
                Start_Date = DateTime.Now,
                Completion_Date = DateTime.Now,
                Project_Status = Project_Status.Completed,
                Project_Priority = Project_Priority.Medium
            }
        );

            modelBuilder.Entity<Task>().HasData(
                new Task
                {
                    TaskID = 1,
                    Name = "First task in first project",
                    Description = "Some description 1",
                    Task_Priority = Task_Priority.Low,
                    Task_Status = Task_Status.To_Do,
                    ProjectID = 1
                },

                new Task
                {
                    TaskID = 2,
                    Name = "Second task in first project",
                    Description = "Some description 2",
                    Task_Priority = Task_Priority.High,
                    Task_Status = Task_Status.In_Progress,
                    ProjectID = 1
                },

                new Task
                {
                    TaskID = 3,
                    Name = "Third task in second project",
                    Description = "Some description 3",
                    Task_Priority = Task_Priority.Medium,
                    Task_Status = Task_Status.To_Do,
                    ProjectID = 2
                }
            );
        }
    }

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }   

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }


}

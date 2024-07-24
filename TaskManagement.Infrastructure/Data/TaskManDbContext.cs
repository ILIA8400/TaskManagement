using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Infrastructure.Data.Entities;
using TaskEntity = TaskManagement.Infrastructure.Data.Entities.Task;

namespace TaskManagement.Infrastructure.Data
{
    public class TaskManDbContext : DbContext
    {
        #region DbSets

        public DbSet<TaskEntity> Tasks { get; set; }

        #endregion

        #region Constructor
        public TaskManDbContext(DbContextOptions<TaskManDbContext> options) : base(options)
        {

        }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        #endregion


    }


    public class ContextFactory : IDesignTimeDbContextFactory<TaskManDbContext>
    {
        public TaskManDbContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<TaskManDbContext>();
            var conection = "Server=127.0.0.1; Database=TaskManagement; User=root; Password=ilia.1384;";
            optionBuilder.UseMySql(
                conection,
                new MySqlServerVersion(new Version(8, 0, 21)),           
                op => op.EnableRetryOnFailure());

            return new TaskManDbContext(optionBuilder.Options);
        }
    }
}

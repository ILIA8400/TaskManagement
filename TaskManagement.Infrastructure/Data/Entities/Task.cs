using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Infrastructure.Data.Entities
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }


    public class TaskConfig : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.Property(c => c.TaskId).HasColumnName("task_id");

            builder.Property(c=>c.Title).HasColumnName("title").HasMaxLength(55);

            builder.Property(c => c.Description).HasColumnName("description").HasMaxLength(255);

            builder.Property(c => c.StartDate).HasColumnName("start_date");

            builder.Property(c => c.EndDate).HasColumnName("end_date");

        }
    }
}

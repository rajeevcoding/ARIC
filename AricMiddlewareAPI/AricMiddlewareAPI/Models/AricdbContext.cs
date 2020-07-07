using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AricMiddlewareAPI.Models
{
    public partial class AricdbContext : DbContext
    {
        public AricdbContext()
        {
        }

        public AricdbContext(DbContextOptions<AricdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AgentMessage> AgentMessage { get; set; }
        public virtual DbSet<ChatSession> ChatSession { get; set; }
        public virtual DbSet<CustomerMessage> CustomerMessage { get; set; }
        public virtual DbSet<WorkFlow> WorkFlow { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgentMessage>(entity =>
            {
                entity.Property(e => e.Message)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChatSession>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<CustomerMessage>(entity =>
            {
                entity.Property(e => e.Message)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorkFlow>(entity =>
            {
                entity.Property(e => e.WorkFlowName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}

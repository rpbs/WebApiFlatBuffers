using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi;

public partial class PresentationContext : DbContext
{
    public PresentationContext()
    {
    }

    public PresentationContext(DbContextOptions<PresentationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Dump> Dumps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Initial Catalog=Presentation;Data Source=localhost;User ID=sa;Password=@F3e88c93;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Dump>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("Users_pk");

            entity.ToTable("Dump");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.FlatBufferData).HasMaxLength(1);
            entity.Property(e => e.JsonData).HasMaxLength(4000);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

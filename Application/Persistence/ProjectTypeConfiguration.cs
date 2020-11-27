using System.ComponentModel.DataAnnotations.Schema;
using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExxerProject.Persistence.Configurators.Projects
{
    public class ProjectTypeConfiguration : IEntityTypeConfiguration<Project>
    {
        public ProjectTypeConfiguration(ModelBuilder modelBuilder)
        {
            Configure(modelBuilder.Entity<Project>());
        }

        public ProjectTypeConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1, 1)
                .IsRequired();

            builder.Property(x => x.Name).HasMaxLength(900).IsRequired();

            builder.HasMany(e => e.Employees)
                .WithMany(e => e.Projects);

            builder.HasMany<Employee>(e => e.Employees);

            builder.HasOne<Budget>(x => x.Budget);
        }
    }
}
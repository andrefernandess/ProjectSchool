using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectSchool.Domain.Models;

namespace ProjectSchool.Persistence.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(s => s.Email).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(s => s.Cpf).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(s => s.Ra).HasColumnType("VARCHAR(80)").IsRequired();

            builder.HasIndex(s => s.Ra).IsUnique();
        }
    }
}
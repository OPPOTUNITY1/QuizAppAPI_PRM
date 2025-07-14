using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using QuizAppAPI_PRM.Models.Domain;

namespace QuizAppAPI_PRM.Data;

public partial class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Information> Informations { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<User> Users { get; set; }
}

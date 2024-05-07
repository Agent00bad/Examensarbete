using Backend.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Database;

public class CvDbContext : DbContext
{
    public DbSet<AboutEntity> Abouts { get; set; }
    public DbSet<AdminEntity> Admins  { get; set; }
    public DbSet<CategoryEntity> Categories  { get; set; }
    public DbSet<CertificationEntity> Certifications  { get; set; }
    public DbSet<ConnectedCompanyEntity> ConnectedCompanies  { get; set; }
    public DbSet<EducationEntity> Educations  { get; set; }
    public DbSet<LanguageEntity> Languages  { get; set; }
    public DbSet<InterestEntity> Interests  { get; set; }
    public DbSet<PersonalProjectEntity> PersonalProjects  { get; set; }
    public DbSet<PersonalProjectUriEntity> PersonalProjectsUris  { get; set; }
    public DbSet<SkillEntity> Skills  { get; set; }
    public DbSet<WorkExperienceEntity> WorkExperiences  { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Connections(modelBuilder);
    }

    /// <summary>
    /// Manages connections between entities
    /// <example>A many to many relation can be configured here since that is a "connection" for example</example>
    /// </summary>
    /// <param name="modelBuilder">The model builder is passed in when called from <c>OnModelCreating</c> override method</param>
    private void Connections (ModelBuilder modelBuilder)
    {
        //Skill related connections
        modelBuilder.Entity<SkillEntity>()
            .HasMany(s => s.PersonalProjects)
            .WithMany(p => p.AsociatedSkills)
            .UsingEntity("ProjectSkill");
        
        modelBuilder.Entity<SkillEntity>()
            .HasMany(s => s.WorkPlaces)
            .WithMany(w => w.AsociatedSkills)
            .UsingEntity("WorkSkill");
        
        modelBuilder.Entity<SkillEntity>()
            .HasMany(s => s.Categories)
            .WithMany(c => c.AsociatedSkills)
            .UsingEntity("SkillCategory");
        
        modelBuilder.Entity<SkillEntity>()
            .HasMany(s => s.Educations)
            .WithMany(e => e.AsociatedSkills)
            .UsingEntity("EducationalSkill");
        
        modelBuilder.Entity<SkillEntity>()
            .HasMany(s => s.Certifications)
            .WithMany(c => c.AsociatedSkills)
            .UsingEntity("SkillCertification");
        
        //TODO: Not sure if this connections will work, test before production
        //Work connections 
        modelBuilder.Entity<ConnectedCompanyEntity>()
            .HasOne(c => c.Work)
            .WithMany()
            .IsRequired();
    }
}
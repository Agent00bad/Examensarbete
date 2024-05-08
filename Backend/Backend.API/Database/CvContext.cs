using Backend.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.API.Database;

public class CvContext : DbContext
{
    public DbSet<AboutEntity> Abouts { get; set; }
    public DbSet<AdminEntity> Admins { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<CertificationEntity> Certifications { get; set; }
    public DbSet<ConnectedCompanyEntity> ConnectedCompanies { get; set; }
    public DbSet<EducationEntity> Educations { get; set; }
    public DbSet<LanguageEntity> Languages { get; set; }
    public DbSet<InterestEntity> Interests { get; set; }
    public DbSet<PersonalProjectEntity> PersonalProjects { get; set; }
    public DbSet<PersonalProjectUriEntity> PersonalProjectUris { get; set; }
    public DbSet<SkillEntity> Skills { get; set; }
    public DbSet<WorkExperienceEntity> WorkExperiences { get; set; }

    public CvContext(DbContextOptions<CvContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Relations(modelBuilder);
    }

    /// <summary>
    /// Manages relations between entities
    /// <example>A many to many relation can be configured here since that is a "connection" for example</example>
    /// </summary>
    /// <param name="modelBuilder">The model builder is passed in when called from <c>OnModelCreating</c> override method</param>
    private void Relations(ModelBuilder modelBuilder)
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
            .HasMany(s => s.Educations)
            .WithMany(e => e.AsociatedSkills)
            .UsingEntity("EducationalSkill");


        //Work relations
        //TODO: Not sure if this connections will work, test before production
        modelBuilder.Entity<ConnectedCompanyEntity>()
            .HasOne(c => c.Work)
            .WithMany()
            .HasForeignKey("WorkId")
            .IsRequired();
        modelBuilder.Entity<WorkExperienceEntity>()
            .HasMany(w => w.ConnectedCompanies)
            .WithOne(c => c.Work);
        //Certification connections
        modelBuilder.Entity<CertificationEntity>()
            .HasMany(c => c.WorkExperiences)
            .WithMany(w => w.Certifications)
            .UsingEntity("WorkCertification");

        modelBuilder.Entity<SkillEntity>()
            .HasMany(s => s.Certifications)
            .WithMany(c => c.AsociatedSkills)
            .UsingEntity("SkillCertification");

        modelBuilder.Entity<CertificationEntity>()
            .HasMany(c => c.Educations)
            .WithMany(e => e.Certifications)
            .UsingEntity("EducationCertification");
        
        //category related relations
        modelBuilder.Entity<CategoryEntity>()
            .HasMany(c => c.AsociatedSkills)
            .WithMany(a => a.Categories)
            .UsingEntity("SkillCategory");
        modelBuilder.Entity<CategoryEntity>()
            .HasMany(s => s.Educations)
            .WithMany(e => e.Categories)
            .UsingEntity("EducationalCategory");
        modelBuilder.Entity<CategoryEntity>()
            .HasMany(c => c.WorkExperiences)
            .WithMany(w => w.Categories)
            .UsingEntity("WorkCategory");
        modelBuilder.Entity<CategoryEntity>()
            .HasMany(c => c.PersonalProjects)
            .WithMany(p => p.Categories)
            .UsingEntity("ProjectCategory");
        modelBuilder.Entity<CategoryEntity>()
            .HasMany(c => c.Certifications)
            .WithMany(c => c.Categories)
            .UsingEntity("CertificationCategory");
        
        //personal projects relations
        modelBuilder.Entity<PersonalProjectUriEntity>()
            .HasOne(p => p.PersonalProject)
            .WithMany()
            .HasForeignKey("ProjectId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        modelBuilder.Entity<PersonalProjectEntity>()
            .HasMany(p => p.ProjectUri)
            .WithOne(p => p.PersonalProject);
    }

    /// <summary>
    /// Manages seed data
    /// </summary>
    /// <param name="builder">passed when calling this method from overload method <c>OnModelCreating</c></param>
    private void SeedData(ModelBuilder builder)
    {
        builder.Entity<AboutEntity>().HasData(
            new AboutEntity
            {
                Id = 1,
                Description = "Hello world! I am a test person and my passions are to test things and just be a test for this database!",
                FirstName = "Sven",
                LastName = "Svenson",
                BirthDate = new DateOnly(1999,01,01),
                ImageUri = "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fimg2-3.timeinc.net%2Fpeople%2Fi%2F2016%2Fnews%2F160620%2Fsweden-day-1024.jpg&f=1&nofb=1&ipt=9f5ea9a7784e3a7327feb4bc406fb3eaf685db0b7dcb55bab20741d488968353&ipo=images",
                
            }
        );
        builder.Entity<AdminEntity>().HasData(new AdminEntity
        {
            Id = 1,
            Email = "test@notreal.com",
            Password = "Notarealorhashedpassword"
        });
        
    }
}
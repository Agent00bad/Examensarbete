using Backend.API.Entities;
using Backend.API.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic.CompilerServices;

namespace Backend.API.Database;

public class CvContext : DbContext
{
    private IConfiguration _config;

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

    public CvContext(DbContextOptions<CvContext> options, IConfiguration config)
        : base(options)
    {
        _config = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Relations(modelBuilder);
        if (_config.GetValue<bool>("Database:Cv:UseSeedData"))
        {
            SeedData(modelBuilder);
            JunktionTableSeedData(modelBuilder);
        }
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

        //About relations
        modelBuilder.Entity<LanguageEntity>()
            .HasOne(l => l.Person)
            .WithMany()
            .HasForeignKey("AboutId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        modelBuilder.Entity<AboutEntity>()
            .HasMany(a => a.Languages)
            .WithOne(l => l.Person);
        modelBuilder.Entity<InterestEntity>()
            .HasOne(i => i.Person)
            .WithMany()
            .HasForeignKey("AboutId")
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        modelBuilder.Entity<AboutEntity>()
            .HasMany(a => a.Interessts)
            .WithOne(i => i.Person);
    }

    /// <summary>
    /// Manages seed data
    /// </summary>
    /// <param name="builder">Is the <c>ModelBuilder</c> in the overloaded method <c>OnModelCreating</c> seen in overload method passed in</param>
    private void SeedData(ModelBuilder builder)
    {
        //Auto generating the amount set at these
        int workExperienceAmount = 6;
        int skillsToAdd = 6;


        builder.Entity<AboutEntity>().HasData(
            new AboutEntity
            {
                Id = 1,
                Description =
                    "Hello world! I am a test person and my passions are to test things and just be a test for this database!",
                FirstName = "Sven",
                LastName = "Svenson",
                BirthDate = new DateOnly(1999, 01, 01),
                ImageUri =
                    "https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fimg2-3.timeinc.net%2Fpeople%2Fi%2F2016%2Fnews%2F160620%2Fsweden-day-1024.jpg&f=1&nofb=1&ipt=9f5ea9a7784e3a7327feb4bc406fb3eaf685db0b7dcb55bab20741d488968353&ipo=images",
            }
        );
        builder.Entity<AdminEntity>().HasData(new AdminEntity
        {
            Id = 1,
            Email = "test@notreal.com",
            Password = "Notarealorhashedpassword"
        });
        builder.Entity<CategoryEntity>()
            .HasData(new
            {
                Id = 1,
                Name = "Test",
            });
        builder.Entity<EducationEntity>()
            .HasData(new EducationEntity
            {
                Id = 1,
                Name = "Test school",
                StartDate = new DateOnly(2020,
                    3,
                    23),
                EndDate = new DateOnly(2024,
                    5,
                    21),
                Description = "Nice school",
            });
        builder.Entity<CertificationEntity>().HasData(new CertificationEntity
        {
            Id = 1,
            Name = "The amazing test certification",
            Description =
                "This test certification is truly amazing, it gives you such amazing privileges like nothing and nothing more. It is truly humbling to be in the presence of someone with a test cert."
        });

        var workEntityList = new List<WorkExperienceEntity>();
        for (int i = 1; i <= workExperienceAmount; i++)
        {
            workEntityList.Add(new WorkExperienceEntity
            {
                Id = i,
                Name = $"work place {i}",
                StartDate = new DateOnly(2020 - i, 2 + i, 1 + i),
                EndDate = i % 3 != 0 ? new DateOnly(2020 + i, 12 - i, 10 - i) : null,
                Relavent = i % 2 == 0,
                Description = $"Great work {i}",
                Role = i % 2 == 0 ? "Fun role" : "Not as nice role"
            });
        }

        builder.Entity<WorkExperienceEntity>().HasData(workEntityList);

        var connectedCompaniesList = new List<Object>();
        for (int i = 1; i < workExperienceAmount / 2; i++)
        {
            connectedCompaniesList.Add(new
            {
                Id = i,
                Description = $"I worked here ",
                WorkId = i == 1 ? i : i % 3 != 0 ? i - (i - 1) : i - (i - 3),
                Name = "ConnectedCompany",
                StartDate = workEntityList[i].StartDate,
                EndDate = workEntityList[i].EndDate,
                Role = workEntityList[i].Role,
            });
        }

        builder.Entity<ConnectedCompanyEntity>().HasData(connectedCompaniesList);

        var interests = new List<object>()
        {
            new { Id = 1, AboutId = 1, Name = "Beatboxing" },
            new
            {
                Id = 2, Name = "Mewing",
                AboutId = 1,
                Description =
                    "Putting my tongue at the roof of my mouth to make my jaw more pronounced... I promise it works!! don't scroll away!!!"
            },
            new
            {
                Id = 3, AboutId = 1, Name = "Turning right", Description = "I don't hate turning left, I just love turning right <3"
            },
            new { Id = 4, AboutId = 1, Name = "Listening to the wind" },
        };
        builder.Entity<InterestEntity>().HasData(interests);

        builder.Entity<LanguageEntity>().HasData(
        [
            new { Id = 1, AboutId = 1, Name = "Swedish", Level = LanguageLevel.Native },
            new { Id = 2, AboutId = 1, Name = "English", Level = LanguageLevel.Professional },
            new { Id = 3, AboutId = 1, Name = "French", Level = LanguageLevel.Beginner },
        ]);

        builder.Entity<PersonalProjectEntity>().HasData(new PersonalProjectEntity
        {
            Id = 1,
            Description = "I once set up a small farm, it was very fun",
            Name = "A small farm",
            Status = PersonalProjectStatus.Finished
        });

        builder.Entity<PersonalProjectUriEntity>().HasData(new
        {
            Id = 1,
            Uri = "https://youtu.be/dQw4w9WgXcQ?si=VmNxHNhgec4fBrg_",
            ProjectId = 1
        });

        var skillList = new List<SkillEntity>();
        for (int i = 1; i < skillsToAdd; i++)
        {
            skillList.Add(new SkillEntity
            {
                Id = i,
                SkillRelevance = (SkillRelevance)(i % (int)SkillRelevance.TopSkill),
                Description = i % 2 == 0 ? $"description for {i}" : null,
                Name = $"Skill {i}",
                SkillLevel = (SkillLevel)(i % (int)SkillLevel.Expert)
            });
        }

        builder.Entity<SkillEntity>().HasData(skillList);
    }

    /// <summary>
    /// For seeding junction tables. Junktion tables are tables that connect many-to-many relations
    /// </summary>
    /// <param name="builder"></param>
    private void JunktionTableSeedData(ModelBuilder builder)
    {
        //Categories
        builder.Entity("CertificationCategory").HasData(new { CategoriesId = 1, CertificationsId = 1 });
        builder.Entity("EducationalCategory").HasData(new { CategoriesId = 1, EducationsId = 1 });
        builder.Entity("ProjectCategory").HasData(new { CategoriesId = 1, PersonalProjectsId = 1 });
        builder.Entity("SkillCategory").HasData(new { CategoriesId = 1, AsociatedSkillsId = 1 });
        builder.Entity("WorkCategory").HasData([
            new { CategoriesId = 1, WorkExperiencesId = 1 }, new { CategoriesId = 1, WorkExperiencesId = 2 }
        ]);

        //Certifications
        builder.Entity("EducationCertification").HasData(new { CertificationsId = 1, EducationsId = 1 });
        builder.Entity("SkillCertification").HasData([
            new { CertificationsId = 1, AsociatedSkillsId = 1 }, new { CertificationsId = 1, AsociatedSkillsId = 2 }
        ]);
        builder.Entity("WorkCertification").HasData([
            new { CertificationsId = 1, WorkExperiencesId = 1 }, new { CertificationsId = 1, WorkExperiencesId = 2 }
        ]);

        //Skills
        builder.Entity("EducationalSkill").HasData([new { AsociatedSkillsId = 1, EducationsId = 1 }]);
        builder.Entity("ProjectSkill").HasData([new { AsociatedSkillsId = 1, PersonalProjectsId = 1 }]);
        builder.Entity("WorkSkill").HasData([new { AsociatedSkillsId = 1, WorkPlacesId = 1 }]);
    }
}
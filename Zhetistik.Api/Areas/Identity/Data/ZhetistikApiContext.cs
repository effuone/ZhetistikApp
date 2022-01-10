using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zhetistik.Api.Areas.Identity.Data;
using Zhetistik.Core.Common;
using Zhetistik.Core.Models;

namespace Zhetistik.Api.Data;

public class ZhetistikApiContext : IdentityDbContext<ZhetistikUser>
{
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Portfolio> Portfolios { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<School> Schools { get; set; }
    public DbSet<SchoolType> SchoolTypes { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<UniversityType> UniversityTypes { get; set; }
    public DbSet<Achievement> Achievements { get; set; }
    public DbSet<AchievementType> AchievementTypes { get; set; }
    public DbSet<Extracurricular> Extracurriculars { get; set; }
    public DbSet<FinancialDoc> FinancialDocs { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<FileStructure> Files { get; set; }
    public ZhetistikApiContext(DbContextOptions<ZhetistikApiContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        //builder.Entity<Achievement>().HasKey(p => p.AchievementID);
        //builder.Entity<AchievementType>().HasKey(p => p.AchievementTypeID);
        //builder.Entity<University>().HasKey(p => p.UniversityID);
        //builder.Entity<UniversityType>().HasKey(p => p.TypeID);
        //builder.Entity<School>().HasKey(p => p.SchoolID);
        //builder.Entity<SchoolType>().HasKey(p => p.TypeID);
        //builder.Entity<Course>().HasKey(p => p.CourseID);
        //builder.Entity<Faculty>().HasKey(p => p.FacultyID);
        //builder.Entity<FileStructure>().HasKey(p => p.FileID);
        //builder.Entity<FinancialDoc>().HasKey(p => p.FinancialID);
        //builder.Entity<Location>().HasKey(p => p.LocationID);
        //builder.Entity<Country>().HasKey(p => p.CountryID);
        //builder.Entity<City>().HasKey(p => p.CityID);
        //builder.Entity<State>().HasKey(p => p.StateID);
        //builder.Entity<Portfolio>().HasKey(p => p.PortfolioID);
    }
}

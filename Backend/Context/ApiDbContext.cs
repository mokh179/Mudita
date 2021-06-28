using Microsoft.EntityFrameworkCore;
using System;
using Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Context
{
    public class ApiDbContext :IdentityDbContext<User>
    {
        public DbSet<AppliedVacancy> AppliedVacancy { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<CompanyVacany> CompanyVacany { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<JobCategory> JobCategory { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleUser> RoleUser { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserCompany> UserCompany { get; set; }
        public DbSet<UserQues> UserQues { get; set; }
        public DbSet<Vacancy> Vacancy { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<locationcompany> Locationcompanies { get; set; }
        public DbSet<JobTypeVacancy> jobTypeVacancies { get; set; }
        public DbSet<KeySkillsVacancy> KeySkillsVacancies { get; set; }



        public DbSet<typeOfEducation> typeOfEducations { get; set; }
        public DbSet<userEducation> userEducations { get; set; }
        public DbSet<userSkills> UserSkills { get; set; }
        public DbSet<KeySkills> KeySkills { get; set; }
        public DbSet<Onlineprofile> Onlineprofiles { get; set; }


        public ApiDbContext(DbContextOptions options) : base(options) { }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=.;initial catalog=GradProj;User ID= mahmoud2611;Password=123456789");
            
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyVacany>().HasKey(vf => new { vf.Company_Id, vf.Vacancy_Id });
            modelBuilder.Entity<RoleUser>().HasKey(vf => new { vf.Role_Id, vf.User_Id });
            modelBuilder.Entity<UserQues>().HasKey(vf => new { vf.Ques_Id, vf.User_Id });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}

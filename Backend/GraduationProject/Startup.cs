using Context;
using GraduationProject.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Models;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationProject
{
    public class Startup
    {
        string MyAllowSpecificOrigins = "metui";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //ApiDBcontext
            services.AddDbContext<ApiDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConntection"));
            });
            //lazy load
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //prevent the looping in data
            services.AddCors(options =>
            {
                options.AddPolicy(name : MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            //To enable Identity.
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApiDbContext>();
            // To use JWT
            services.Configure<JWT>(Configuration.GetSection("JWT"));
            //To use JWT token gllobally
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(op =>
            {
                op.RequireHttpsMetadata = false;
                op.SaveToken = false;
                //to validate Token Data
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                };
            });
            services.AddScoped<Iauth, auth>();
            services.AddScoped<IRating, Rate>();
            services.AddScoped<ICompany, CompanyMoc>();
            services.AddScoped<IDBOperations<City>, CityMoc>();
            services.AddScoped<IInterviewQues, InterviewQuesMoc>();
            services.AddScoped<IDBOperations<Countries>, CountryMoc>();
            services.AddScoped<IDBOperations<Category>, CategoryMoc>();            
            services.AddScoped<IDBOperations<KeySkills>, KeySkillsMoc>();
            services.AddScoped<IDBOperations<JobCategory>, JobCategoryMoc>();
            services.AddScoped<IDBOperations<KeySkills>, KeySkillsMoc>();
            services.AddScoped<IDBOperations<JobType>, JobtypesMoc>();
            services.AddScoped<IEducation, EducationMoc>();


            services.AddTransient<IVacancy, vacancyMoc>();
            services.AddTransient<IUser, UserMoc>();
            services.AddScoped<IAdmin, AdminMoc>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GraduationProject", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GraduationProject v1"));
            }

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);

            //File path
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources")
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

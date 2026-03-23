using System.Text;
using Amazon.S3;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Yad2.Data;
using Yad2.Models;
using Yad2.Repositories;

namespace Yad2
{
    public class Program
    {
         public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                   

            var connectionString =
    builder.Configuration.GetConnectionString("Yad2")
    ?? builder.Configuration["ConnectionStrings__Yad2"];

builder.Services.AddDbContext<Yad2Context>(options =>
    options.UseMySql(
        connectionString,
        new MySqlServerVersion(new Version(8, 0, 0))
    ));

            builder.Services.AddIdentity<UserModel, IdentityRole>()
           .AddEntityFrameworkStores<Yad2Context>()
           .AddDefaultTokenProviders();

           var jwtSecret =
            builder.Configuration["JWT:Secret"]
            ?? builder.Configuration["JWT__Secret"]
            ?? throw new Exception("JWT Secret is missing");


          builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(option =>
{
    var jwtSecret =
        builder.Configuration["JWT:Secret"]
        ?? builder.Configuration["JWT__Secret"]
        ?? throw new Exception("JWT Secret is missing");

   

    option.SaveToken = true;
    option.RequireHttpsMetadata = false;
    option.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
    };

            option.Events = new JwtBearerEvents
            {
                OnMessageReceived = ctx =>
                {
                    ctx.Request.Cookies.TryGetValue("access_token", out var accessToken);

                    if (!string.IsNullOrEmpty(accessToken))
                    {
                        ctx.Token = accessToken;
                    }

                    return Task.CompletedTask;
                }
            };
        })
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, option =>
        {
            option.Cookie.HttpOnly = true;
            option.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        });

            builder.Services.Configure<IdentityOptions>(
                option => {
                    option.Password.RequireUppercase = true;
                    option.Password.RequireDigit = true;
                    option.Password.RequireNonAlphanumeric = true;
                    option.Password.RequiredLength = 8;

                }
            );

            builder.Services.AddControllers().AddNewtonsoftJson(option =>
            {
                option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

             builder.Services.AddScoped<IUserRepository,UserRepository>();
            builder.Services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options => {
               
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
            builder.Services.AddAWSService<IAmazonS3>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // Middleware starts here
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseCors("AllowFrontend");

             app.UseAuthentication();

            app.UseAuthorization();

            
            app.MapControllers();

            // Middleware ends here

            app.Run();
        }
    }
}
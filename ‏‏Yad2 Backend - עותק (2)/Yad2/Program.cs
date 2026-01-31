using System.Text;
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

           

            builder.Services.AddDbContext<Yad2Context>(
                  option => option.UseSqlServer(
                      builder.Configuration.GetConnectionString("Yad2")
                  )
              );

            builder.Services.AddIdentity<UserModel, IdentityRole>()
           .AddEntityFrameworkStores<Yad2Context>()
           .AddDefaultTokenProviders();


            builder.Services.AddAuthentication(option => {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            })

            .AddJwtBearer(option => {

                option.SaveToken = true;
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:ValidAudience"],
                    ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
                };
                option.Events = new JwtBearerEvents
                {
                    OnMessageReceived = ctx =>
                    {
                        ctx.Request.Cookies.TryGetValue("access_token", out var access_token);
                        if (!string.IsNullOrEmpty(access_token)){
                            ctx.Token = access_token;
                        }

                        return Task.CompletedTask;




                    }
                };


            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, option =>
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
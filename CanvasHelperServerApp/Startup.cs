using Blazored.SessionStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using CanvasHelperServerApp.Models;
using CanvasHelperServerApp.Pages.Authentication;
using CanvasHelperServerApp.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace CanvasHelperServerApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            
            services.AddDbContext<Models.CanvasDbContext>(o => {
                o.UseSqlite(Configuration.GetConnectionString("sqlite"), q => q.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
                //o.UseSqlServer(Configuration.GetConnectionString("sqlserverconn"), q => q.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
                o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddRazorPages();

            services.AddServerSideBlazor().AddCircuitOptions(option => { option.DetailedErrors = true; });

             services.AddOptions();
             services.AddAuthorizationCore();
            //services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
             services.AddScoped<CustomAuthenticationStateProvider>();
             services.AddScoped<AuthenticationStateProvider>(provider =>
             provider.GetRequiredService<CustomAuthenticationStateProvider>());
              
            services
                .AddBlazorise(options => {
                    options.DelayTextOnKeyPress = true;
                })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            services.AddScoped<IBaseRepository<Assignment>, BaseRepository<Assignment>>();
            services.AddScoped<IBaseRepository<AssignmentsType>, BaseRepository<AssignmentsType>>();
            services.AddScoped<IBaseRepository<Course>, BaseRepository<Course>>();
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IBaseRepository<Criterion>, BaseRepository<Criterion>>();
            services.AddScoped<IBaseRepository<FavoriteFeedback>, BaseRepository<FavoriteFeedback>>();
            services.AddScoped<IBaseRepository<Feedback>, BaseRepository<Feedback>>();
            services.AddScoped<IBaseRepository<UsersCriteriaFeedback>, BaseRepository<UsersCriteriaFeedback>>(); 

            services.AddBlazoredSessionStorage();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, CanvasDbContext context) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            context.Database.EnsureCreated();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints => {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SEIIApp.Server.DataAccess;
using System;
using System.IO;
using System.Reflection;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;


namespace SEIIApp.Server {
    /// <summary>
    /// Startup of the webapp.
    /// </summary>
    public class Startup {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDb");
            });

            services.AddScoped<Services.CourseService>();
            services.AddScoped<Services.LessonService>();
            services.AddScoped<Services.QuizService>();
            services.AddScoped<Services.StudentService>();
            services.AddScoped<Services.AvatarService>();
            services.AddScoped<Services.AvatarItemService>();
            services.AddScoped<Services.CorrectQuestionService>();
            services.AddScoped<Services.FinishedQuizService>();

            services.AddSwaggerGen(options => {

                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Backend Server API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath);
            });

            services.AddAutoMapper(typeof(Domain.DomainMapper));

            services
                .AddBlazorise(options =>
                {
                    options.ChangeTextOnKeyPress = true;
                })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseContext db) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");

                app.UseSwagger();
                app.UseSwaggerUI(options => {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Spezifikation");
                });
            });

            ContentData.GenerateData(db);
        }
    }
}

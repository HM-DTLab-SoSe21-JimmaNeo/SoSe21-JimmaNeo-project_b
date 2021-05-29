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
using SEIIApp.Server.Services;
using System.Linq;

namespace SEIIApp.Server {
    public class Startup {
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
            services.AddScoped<Services.AvatarItemService>();
            services.AddScoped<Services.CorrectQuestionService>();

            services.AddSwaggerGen(options => {

                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Backend Server API", Version = "v1" });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                //Wenn hier ein Fehler auftritt, dann aktivieren Sie in den Einstellungen des 
                //Projektes → Rechte Maustaste auf SEIIApp.Server → Eigenschaften
                //im Tab "Build" die Option "XML-Dokumentationsdatei" und geben dort ein:
                //$(MSBuildProjectDirectory)\SEIIApp.Server.xml
                options.IncludeXmlComments(xmlPath);
            });
            //AutoMapper
            //https://docs.automapper.org/en/latest/Getting-started.html
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

                //endpoints.MapBlazorHub();
                //endpoints.MapFallbackToPage("/_Host");

                app.UseSwagger();
                app.UseSwaggerUI(options => {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Spezifikation");
                });
            });

            TestDataGenerator.GenerateData(db);

            /*
            //***************************************************************
            //***************************************************************

            //Helper function
            //Do something in in isolated database context scope
            void DoInIsolatedScopeWithStudentService(Action<StudentService> action) {
                //create db scope
                using (var scope = app.ApplicationServices.CreateScope()) {
                    var service = scope.ServiceProvider.GetRequiredService<StudentService>();
                    action(service);
                }//dispose scope
            }

            DoInIsolatedScopeWithStudentService(ss => {
                var student = ss.GetAllStudents().First();
                student.CorrectQuestions.Add(new Domain.CorrectQuestion() {
                    QuestionsId = 1,
                    SolveDateTime = DateTime.Now
                });
                ss.UpdateStudent(student);
            });

            DoInIsolatedScopeWithStudentService(ss => {
                var student = ss.GetAllStudents().First();
                student.CorrectQuestions.Add(new Domain.CorrectQuestion() {
                    QuestionsId = 1,
                    SolveDateTime = DateTime.Now
                });
                ss.UpdateStudent(student);
            });
            */
        }
    }
}

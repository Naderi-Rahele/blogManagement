using BlogManagement.Core.ApplicationServices.Blogs;
using BlogManagement.Core.ApplicationServices.Comments;
using BlogManagement.Core.ApplicationServices.Posts;
using BlogManagement.Core.ApplicationServices.Visits;
using BlogManagement.Core.Domain.Blogs;
using BlogManagement.Core.Domain.Comments;
using BlogManagement.Core.Domain.Posts;
using BlogManagement.Core.Domain.Visits;
using BlogManagement.Endpoints.API.Controllers.Filters;
using BlogManagement.Infra.Data.Sql.Blogs;
using BlogManagement.Infra.Data.Sql.Comments;
using BlogManagement.Infra.Data.Sql.Common;
using BlogManagement.Infra.Data.Sql.Posts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogManagement.Endpoints.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(f =>
            {
                f.Filters.Add(typeof(InputFilter));
                f.Filters.Add(typeof(ExceptionFilter));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlogManagement.Endpoints.API", Version = "v1" });
            });

            services.AddDbContext<BlogManagementDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BlogManagementCnn")));
            services.AddScoped<BlogRepository, EfBlogRepository>();
            services.AddScoped<BlogApplicaitonService>();
            services.AddScoped<PostRepository, EfPostRepository>();
            services.AddScoped<PostApplicationService>();
            services.AddScoped<CommentRepository, EfCommentRepository>();
            services.AddScoped<CommentApplicationService>();
            services.AddScoped<VisitRepository, Infra.Data.Sql.Visits.EfVisitRepository>();
            services.AddScoped<VisitApplicationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlogManagement.Endpoints.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.Use(async (context, next) =>
            {
                logger.LogInformation($"ip:{context.Connection.RemoteIpAddress},date:{DateTime.Now},request:{context.Request.Path}");
                await next.Invoke();
                logger.LogInformation($"result:{context.Response.StatusCode}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

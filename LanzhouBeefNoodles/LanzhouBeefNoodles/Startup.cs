using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanzhouBeefNoodles.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LanzhouBeefNoodles
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //在ConfigureServices里面注入各种服务组件的依赖
        public void ConfigureServices(IServiceCollection services)
        {
            //注入数据库服务器连接
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //注册Mvc服务的组件
            services.AddMvc();
            //使用NoodleRepository仓库服务，需要在这里进行服务注册
            services.AddTransient<INoodleRepository, NoodleRepository>(); //每次请求创建一个新的仓库，操作独立
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            //services.AddSingleton; //单例创建仓库
            //service.AddScoped;  //引入事务管理，创建一个仓库
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //创建中间件，设置请求通道Request Pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //加载静态文件的中间件--会检测ccs样式类文件，避免页面输出异常
            app.UseStaticFiles();

            //使用UseMvcWithDefaultRoute与UserMvc都可以自定义初始化路由信息
            //app.UseMvcWithDefaultRoute();
            //使用自定义路由
            app.UseMvc(route =>
            {
                //通配所有的controller和action，如果有参数的话，参数为id
                route.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            }
            );

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            //任何在app.Run之后的代码都不会被执行
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanzhouBeefNoodles.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace LanzhouBeefNoodles
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        //在ConfigureServices里面注入各种服务组件的依赖
        public void ConfigureServices(IServiceCollection services)
        {
            //注册Mvc服务的组件
            services.AddMvc();
            //使用NoodleRepository仓库服务，需要在这里进行服务注册
            services.AddTransient<INoodleRepository, MockNoodleRepository>(); //每次请求创建一个新的仓库，操作独立
            services.AddTransient<IFeedbackRepository, MockFeedbackRepository>();
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

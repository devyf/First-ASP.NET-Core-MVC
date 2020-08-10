using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //创建中间件，设置请求通道Request Pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //对请求url进行截获处理，异步输出hello from test
            app.Map("/test", build =>
            {
                build.Run(async context =>
                {
                    await context.Response.WriteAsync("hello from test");
                });
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            //任何在app.Run之后的代码都不会被执行
        }
    }
}

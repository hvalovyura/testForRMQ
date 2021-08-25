using ItSymphony.Integration.DeltaM.Contracts;
using ItSymphony.Integration.DeltaM.Contracts.Models;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testForRMQ
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
            services.AddControllers();
            var bus = Bus.Factory.CreateUsingRabbitMq(config => {
                config.Host("amqp://guest:guest@localhost:5672");
                config.ReceiveEndpoint("ChatCloseQueue", c =>
                {
                    c.Handler<ChatClosedEvent>(ctx =>
                    {
                        return Console.Out.WriteLineAsync(JsonConvert.SerializeObject(ctx.Message.Model));
                    });
                    
                });
            });

            var bus3 = Bus.Factory.CreateUsingRabbitMq(config => {
                config.Host("amqp://guest:guest@localhost:5672");
                config.ReceiveEndpoint("NewMessageQueue", c =>
                {
                    c.Handler<NewMessageEvent>(ctx =>
                    {
                        return Console.Out.WriteLineAsync(JsonConvert.SerializeObject(ctx.Message.Model));
                    });
                });
            });
            bus.Start();

            bus3.Start();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

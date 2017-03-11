namespace DataCat.Microservice.Core
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Options;

    public class StartupBase
    {
        public IConfigurationRoot Configuration { get; }

        protected Func<IConfigurationBuilder, IConfigurationBuilder> ConfigureStartupConfiguration { get;  set; }

        public StartupBase(IHostingEnvironment env)
        {
            var startupConfigurationBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                startupConfigurationBuilder.AddApplicationInsightsSettings(developerMode: true);
            }

            startupConfigurationBuilder.AddEnvironmentVariables();

            startupConfigurationBuilder = this.ConfigureStartupConfiguration == null ?
                ConfigureStartupConfiguration(startupConfigurationBuilder) : startupConfigurationBuilder;

            Configuration = startupConfigurationBuilder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddCors();
            services.AddResponseCompression();

            var databaseConfig = Configuration.GetSection("Database");
            services.Configure<DatabaseOptions>(databaseConfig);

            services.AddMvc();
        }

        public virtual void Configure(
            IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseApplicationInsightsRequestTelemetry();
            app.UseApplicationInsightsExceptionTelemetry();
            app.UseResponseCompression();

            app.UseMvc();
        }
    }
}

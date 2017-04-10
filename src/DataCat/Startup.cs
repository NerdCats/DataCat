namespace DataCat
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using DataCat.Core.Converters;
    using DataCat.Microservice.Core.Options;
    using DataCat.Core.Db;
    using DataCat.Core.Services;
    using DataCat.ActionFilter;

    public class Startup
    {
        private IHostingEnvironment environment;

        public Startup(IHostingEnvironment env)
        {
            this.environment = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddCors();
            services.AddResponseCompression();

            var databaseConfig = Configuration.GetSection("Database");

            // Initiate a dbContext      
            services.AddSingleton<IDbContext, DbContext>((provider) =>
            {
                var dbContext = new DbContext(databaseConfig["ConnectionString"], databaseConfig["DatabaseName"]);
                return dbContext;
            });

            services.AddSingleton<IDataConnectionService, DataConnectionService>();
            services.AddSingleton<IFilterService, FilterService>();
            services.AddSingleton<IWidgetService, WidgetService>();

            services.AddMvc(options =>
                {
                    options.Filters.Add(new ServerExceptionFilter(environment));
                })
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new BsonDocumentConverter());
                    options.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseResponseCompression();

            var securityOptions = new SecurityOptions();
            Configuration.GetSection("Security").Bind(securityOptions);

            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = securityOptions.Authority,
                AllowedScopes = securityOptions.AllowedScopes,
                RequireHttpsMetadata = securityOptions.RequireHttpsMetadata
            });

            app.UseMvc();
        }
    }
}

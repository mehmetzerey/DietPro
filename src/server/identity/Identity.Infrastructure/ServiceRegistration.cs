using Identity.Infrastructure.Repository.Role;
using Identity.Infrastructure.Repository.User;

namespace Identity.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfastructureServiceRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppIdentityDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("IdentityConnectionString"), b => b.MigrationsAssembly("Identity.API")));

        // rol bazlı attribute lar çalışsın diye eklendi
        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<AppIdentityDbContext>().AddDefaultTokenProviders();

        string secretStr = configuration["Application:Secret"];
        byte[] secret = Encoding.UTF8.GetBytes(secretStr);

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.Audience = configuration["Application:Audience"];
            options.SaveToken = true;
            options.RequireHttpsMetadata = false;
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(secret),
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = true,
                ClockSkew = TimeSpan.Zero
            };
        });

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IReadUserRepository, ReadUserRepository>();
        services.AddScoped<IWriteUserRepository, WriteUserRepository>();
        services.AddScoped<IWriteRoleRepository, WriteRoleRepository>();
        return services;
    }
}

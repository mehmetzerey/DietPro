namespace Identity.Infrastructure.Context;
public class AppIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public readonly IHttpContextAccessor httpContextAccessor;
    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options)
    {
        this.httpContextAccessor = httpContextAccessor;
    }
    public DbSet<ApplicationUserToken> ApplicationUserTokens { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new IdentityRoleEntityTypeConfiguration());
        base.OnModelCreating(builder);
    }
}

namespace Identity.Infrastructure.Configuration;

class IdentityRoleEntityTypeConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> roleConfiguration)
    {
        roleConfiguration.HasData(RoleEnum.List().ToArray());

    }
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddInfastructureServiceRegistration(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddControllersWithViews()
                .AddViewLocalization();

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new("tr-TR");

    CultureInfo[] cultures = new CultureInfo[]
    {
        new("tr-TR"),
        new("en-US")
    };

    options.SupportedCultures = cultures;
    options.SupportedUICultures = cultures;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRequestLocalization();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

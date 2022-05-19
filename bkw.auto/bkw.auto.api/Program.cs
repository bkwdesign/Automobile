var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<bkw.auto.interfaces.IVehicleOptionsProvider, bkw.auto.provider.CompiledVehicleOptionsProvider>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SchemaFilter<bkw.auto.api.EnumSchemaFilter>();
    c.MapType<bkw.auto.interfaces.VehicleKind>(() => new Microsoft.OpenApi.Models.OpenApiSchema { Type = "string", Format = "string" });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

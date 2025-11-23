using AuthService.Infrastructure.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application + Infrastructure
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Default
app.MapGet("/", () => "Auth Service Running...");

// Endpoints
AuthEndpoints.Map(app);
TokenEndpoints.Map(app);

app.Run();
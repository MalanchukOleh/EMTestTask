using EMTestTask.Models;
using EMTestTask.Sevices;

var SpecificOrigins = "CORSForClientSide";
var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<CustomersDatabaseSettings>(
    builder.Configuration.GetSection("CustomersDatabaseSettings"));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: SpecificOrigins,
        policy =>
        {
            policy.WithOrigins()
                .AllowAnyHeader()  
                .AllowAnyMethod(); 
        });
});
builder.Services.AddSingleton<CustomersService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseCors(SpecificOrigins);
app.MapControllers();
app.UseHttpsRedirection();
app.Run();

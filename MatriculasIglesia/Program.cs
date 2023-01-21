

using MatriculasIglesia.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager configuration = builder.Configuration;
builder.Services.AddRegistration(configuration);


var app = builder.Build();
app.UseCors(option => option.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin());


IoCRegister.AddRegistration(app, app.Environment);

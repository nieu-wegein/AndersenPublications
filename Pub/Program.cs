using Microsoft.AspNetCore.Diagnostics;
using Pub.Api.Middleware;
using Pub.Application;
using Pub.Infrastructure;
using Pub.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.OAuth;
using System.Text;
using System.Text.Json.Serialization;
using Pub.Api.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opt =>
{
	opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
}); 
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddAuth();

var app = builder.Build();


app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

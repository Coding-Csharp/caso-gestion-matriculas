using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using CasoGestionMatriculas.Operation.Application.Internal.CommandServices;
using CasoGestionMatriculas.Operation.Application.Internal.QueryServices;
using CasoGestionMatriculas.Operation.Domain.Repositories;
using CasoGestionMatriculas.Operation.Domain.Services;
using CasoGestionMatriculas.Operation.Infrastructure.Persistence.Repositories;
using CasoGestionMatriculas.Shared.Domain.Repositories;
using CasoGestionMatriculas.Shared.Infrastructure.Persistence.EFC.Configuration;
using CasoGestionMatriculas.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DataBase Configuration

builder.Services.AddTransient<IDbConnection>(db =>

    new SqlConnection(builder.Configuration
    .GetConnectionString("CasoGestionMatriculas"))
);
builder.Services.AddDbContext<CasoGestionMatriculasContext>(options =>
{
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("CasoGestionMatriculas"));
});

#endregion

#region Dependencies Injections

builder.Services.AddScoped<ICourseCommandService, CourseCommandService>();
builder.Services.AddScoped<ICourseQueryService, CourseQueryService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();

builder.Services.AddScoped<IStudentCommandService, StudentCommandService>();
builder.Services.AddScoped<IStudentQueryService, StudentQueryService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddScoped<IRegistrationCommandService, RegistrationCommandService>();
builder.Services.AddScoped<IRegistrationQueryService, RegistrationQueryService>();
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(
    c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
using System.Text.RegularExpressions;
using DevCandidateTest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EmployeesContext>(opt => opt.UseInMemoryDatabase("datastoredb"));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/createdb", async ([FromServices] EmployeesContext context) =>
{
    context.Database.EnsureCreated();
    return Results.Ok("Base de datos en memoria creada: " + context.Database.IsInMemory());
});

app.MapGet("/api/employeelist", async ([FromServices] EmployeesContext context, HttpContext httpcontext) =>
{
    context.Database.EnsureCreated();
    return Results.Ok(context.Employee);

});

app.MapGet("/api/employeelistsorted", async ([FromServices] EmployeesContext context, HttpContext httpcontext) =>
{
    context.Database.EnsureCreated();

    if (httpcontext.Request.Query.Any(x => x.Key == "SortByName"))
    {
        return Results.Ok(context.Employee.OrderBy(x => x.BornDate).ThenBy(x => x.Name));
    }
    else
    {
        return Results.Ok(context.Employee.OrderByDescending(x => x.BornDate));
    }

});

app.MapPost("api/newemployee", async ([FromServices] EmployeesContext context, [FromBody] Employee employee) =>
{
    context.Database.EnsureCreated();
    var rfcExists = context.Employee.Where(x => x.RFC == employee.RFC);
    Regex rx = new Regex("^[A-ZÑ&]{3,4}\\d{6}[A-V1-9][0-9A-Z]([0-9A])?$");
    if (rfcExists == null || !rfcExists.Any())
    {
        if (rx.IsMatch(employee.RFC))
        {
            employee.Id = Guid.NewGuid();
            //employee.BornDate = DateTime.Now;
            await context.Employee.AddAsync(employee);
            await context.SaveChangesAsync();
            return Results.Ok("Empleado registrado");
        }
        else{
            return Results.Problem("RFC Invalido");
        }
    }
    return Results.Problem("Este RFC ya existe");
});

app.Run();

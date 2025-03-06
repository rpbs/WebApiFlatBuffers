using System.Data;
using FlatBuffersModels;
using Google.FlatBuffers;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.MapGet("/flatbuffers", (HttpRequest request) =>
{

    var queryString = request.Query.FirstOrDefault(x => x.Key == "size");
    
    var size = Convert.ToInt32(queryString.Value);
        
    FlatBufferBuilder buffer = new FlatBufferBuilder(1024);

    List<Offset<Employee>> employees = [];

    for (int i = 0; i < size; i++)
    {
        StringOffset nameOffset = buffer.CreateString($"Nome {i}");
        StringOffset emailOffset = buffer.CreateString($"email{i}@email.com");        
        Offset<Employee> employee = Employee.CreateEmployee(buffer, i, nameOffset, emailOffset);
        
        employees.Add(employee);
    }

    VectorOffset employeeList = buffer.CreateVectorOfTables(employees.ToArray());

    Company.StartCompany(buffer);
    Company.AddCompanyId(buffer, 1);
    Company.AddEmployees(buffer, employeeList);

    var company = Company.EndCompany(buffer);

    buffer.Finish(company.Value);

    byte[] bufferArray = buffer.SizedByteArray();
    
    Console.WriteLine($"{DateTime.Now} - Buffer size: {bufferArray.Length}");

    var result = new FileContentResult(bufferArray, "application/octet-stream");

    Console.WriteLine($"{DateTime.Now} - Result size: {result.FileContents.Length}");
    
    return Results.File(bufferArray, "application/octet-stream");
});

app.MapGet("/json", (HttpRequest request) =>
{
    var queryString = request.Query.FirstOrDefault(x => x.Key == "size");
    
    var size = Convert.ToInt32(queryString.Value);
    
    List<WebApi.Entities.Employee> employees = [];

    for (var i = 0; i < size; i++)
    {
        employees.Add(new WebApi.Entities.Employee()
        {
            EmployeeId = i,
            Email = $"email{i}@email.com",
            Name = $"Nome {i}",
        });
    }

    var company = new WebApi.Entities.Company()
    {
        Employees = employees,
        CompanyId = 1
    };

    return company;
});

app.Run();



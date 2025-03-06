namespace WebApi.Entities;

public class Company
{
    public int CompanyId { get; set; }
    public IEnumerable<Employee> Employees { get; set; }
}
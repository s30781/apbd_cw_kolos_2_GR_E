namespace Kolos_2_s_30781_GR_E.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public ICollection<EmployeeBatch> EmployeeBatches { get; set; } = new List<EmployeeBatch>();
}
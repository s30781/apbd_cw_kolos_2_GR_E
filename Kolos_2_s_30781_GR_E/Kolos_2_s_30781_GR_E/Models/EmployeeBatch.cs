namespace Kolos_2_s_30781_GR_E.Models;


public class EmployeeBatch
{
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;

    public int BatchId { get; set; }
    public Batch Batch { get; set; } = null!;

    public string Role { get; set; } = null!;
}
namespace Kolos_2_s_30781_GR_E.DTOs;

public class AddBatchDto
{
    public int Quantity { get; set; }
    public string Species { get; set; } = null!;
    public string Nursery { get; set; } = null!;
    public List<EmployeeRoleDto> Responsible { get; set; } = new();
}

public class EmployeeRoleDto
{
    public int EmployeeId { get; set; }
    public string Role { get; set; } = null!;
}

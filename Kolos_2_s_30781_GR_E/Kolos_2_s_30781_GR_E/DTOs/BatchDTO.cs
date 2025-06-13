namespace Kolos_2_s_30781_GR_E.DTOs;

public class BatchDto
{
    public int BatchId { get; set; }
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime ReadyDate { get; set; }

    public SpeciesDto Species { get; set; } = null!;
    public List<EmployeeWithRoleDto> Responsible { get; set; } = new();
}

public class SpeciesDto
{
    public string LatinName { get; set; } = null!;
    public int GrowthTimeInYears { get; set; }
}

public class EmployeeWithRoleDto
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Role { get; set; } = null!;
}

namespace Kolos_2_s_30781_GR_E.DTOs;

public class NurseryDto
{
    public int NurseryId { get; set; }
    public string Name { get; set; } = null!;
    public DateTime EstablishedDate { get; set; }
    public List<BatchDto> Batches { get; set; } = new();
}

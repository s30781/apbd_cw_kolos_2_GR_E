namespace Kolos_2_s_30781_GR_E.Models;

public class Batch
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public DateTime SownDate { get; set; }
    public DateTime ReadyDate { get; set; }

    public int SpeciesId { get; set; }
    public Species Species { get; set; } = null!;

    public int NurseryId { get; set; }
    public Nursery Nursery { get; set; } = null!;

    public ICollection<EmployeeBatch> EmployeeBatches { get; set; } = new List<EmployeeBatch>();
}
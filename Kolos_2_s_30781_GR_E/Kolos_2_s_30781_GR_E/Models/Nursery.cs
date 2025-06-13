namespace Kolos_2_s_30781_GR_E.Models;

public class Nursery
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime EstablishedDate { get; set; }

    public ICollection<Batch> Batches { get; set; } = new List<Batch>();
}
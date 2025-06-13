namespace Kolos_2_s_30781_GR_E.Models;

public class Species
{
    public int Id { get; set; }
    public string LatinName { get; set; } = null!;
    public int GrowthTimeInYears { get; set; }

    public ICollection<Batch> Batches { get; set; } = new List<Batch>();
}
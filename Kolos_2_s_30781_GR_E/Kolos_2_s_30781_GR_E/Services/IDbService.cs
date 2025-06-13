using Kolos_2_s_30781_GR_E.DTOs;

namespace Kolos_2_s_30781_GR_E.Services;

public interface IDbService
{
    Task<NurseryDto?> GetNurseryWithBatchesAsync(int id);
    Task AddBatchAsync(AddBatchDto dto);
}


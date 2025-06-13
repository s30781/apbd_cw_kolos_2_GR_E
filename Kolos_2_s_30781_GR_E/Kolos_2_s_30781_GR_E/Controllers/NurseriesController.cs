using Kolos_2_s_30781_GR_E.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos_2_s_30781_GR_E.Controllers;

[ApiController]
[Route("api/nurseries")]
public class NurseriesController : ControllerBase
{
    private readonly IDbService _dbService;

    public NurseriesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/batches")]
    public async Task<IActionResult> GetNurseryWithBatches(int id)
    {
        var result = await _dbService.GetNurseryWithBatchesAsync(id);
        if (result == null) return NotFound("Nursery not found");
        return Ok(result);
    }
}
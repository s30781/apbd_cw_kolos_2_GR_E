using Kolos_2_s_30781_GR_E.DTOs;
using Kolos_2_s_30781_GR_E.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolos_2_s_30781_GR_E.Controllers;

[ApiController]
[Route("api/batches")]
public class BatchesController : ControllerBase
{
    private readonly IDbService _dbService;

    public BatchesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddBatch(AddBatchDto dto)
    {
        try
        {
            await _dbService.AddBatchAsync(dto);
            return Ok("Batch added successfully");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
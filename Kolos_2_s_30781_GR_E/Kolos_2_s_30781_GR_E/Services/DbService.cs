using Kolos_2_s_30781_GR_E.Data;
using Kolos_2_s_30781_GR_E.DTOs;
using Kolos_2_s_30781_GR_E.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolos_2_s_30781_GR_E.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<NurseryDto?> GetNurseryWithBatchesAsync(int id)
    {
        var nursery = await _context.Nurseries
            .Include(n => n.Batches)
                .ThenInclude(b => b.Species)
            .Include(n => n.Batches)
                .ThenInclude(b => b.EmployeeBatches)
                    .ThenInclude(eb => eb.Employee)
            .FirstOrDefaultAsync(n => n.Id == id);

        if (nursery is null) return null;

        return new NurseryDto
        {
            NurseryId = nursery.Id,
            Name = nursery.Name,
            EstablishedDate = nursery.EstablishedDate,
            Batches = nursery.Batches.Select(b => new BatchDto
            {
                BatchId = b.Id,
                Quantity = b.Quantity,
                SownDate = b.SownDate,
                ReadyDate = b.ReadyDate,
                Species = new SpeciesDto
                {
                    LatinName = b.Species.LatinName,
                    GrowthTimeInYears = b.Species.GrowthTimeInYears
                },
                Responsible = b.EmployeeBatches.Select(eb => new EmployeeWithRoleDto
                {
                    FirstName = eb.Employee.FirstName,
                    LastName = eb.Employee.LastName,
                    Role = eb.Role
                }).ToList()
            }).ToList()
        };
    }

    public async Task AddBatchAsync(AddBatchDto dto)
    {
        var nursery = await _context.Nurseries.FirstOrDefaultAsync(n => n.Name == dto.Nursery)
                      ?? throw new Exception("Nursery not found");

        var species = await _context.Species.FirstOrDefaultAsync(s => s.LatinName == dto.Species)
                      ?? throw new Exception("Species not found");

        var batch = new Batch
        {
            Quantity = dto.Quantity,
            SownDate = DateTime.Now,
            ReadyDate = DateTime.Now.AddYears(species.GrowthTimeInYears),
            NurseryId = nursery.Id,
            SpeciesId = species.Id
        };

        foreach (var responsible in dto.Responsible)
        {
            var employee = await _context.Employees.FindAsync(responsible.EmployeeId)
                           ?? throw new Exception("Employee not found");

            batch.EmployeeBatches.Add(new EmployeeBatch
            {
                EmployeeId = employee.Id,
                Role = responsible.Role
            });
        }

        _context.Batches.Add(batch);
        await _context.SaveChangesAsync();
    }
}

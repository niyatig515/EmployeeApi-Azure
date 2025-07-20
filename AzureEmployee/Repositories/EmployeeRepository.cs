using EmployeeApi.Data;
using EmployeeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AppDbContext _db;
    public EmployeeRepository(AppDbContext db) => _db = db;

    public Task<List<Employee>> GetAllAsync(CancellationToken ct = default) => _db.Employees.AsNoTracking().ToListAsync(ct);

    public Task<Employee?> GetByIdAsync(int id, CancellationToken ct = default) => _db.Employees.AsNoTracking().FirstOrDefaultAsync(e => e.EmployeeId == id, ct);

    public async Task<Employee> AddAsync(Employee employee, CancellationToken ct = default)
    {
        _db.Employees.Add(employee);
        await _db.SaveChangesAsync(ct);
        return employee;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct = default)
    {
        var entity = await _db.Employees.FindAsync(new object?[] { id }, ct);
        if (entity is null)
            return false;
        _db.Employees.Remove(entity);
        await _db.SaveChangesAsync(ct);
        return true;
    }

    public Task<int> SaveChangesAsync(CancellationToken ct = default) => _db.SaveChangesAsync(ct);
}
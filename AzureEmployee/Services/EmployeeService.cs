using EmployeeApi.DTOs;
using EmployeeApi.Models;
using EmployeeApi.Repositories;

namespace EmployeeApi.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repo;
    public EmployeeService(IEmployeeRepository repo) => _repo = repo;

    public Task<List<Employee>> GetAllAsync(CancellationToken ct = default) => _repo.GetAllAsync(ct);

    public Task<Employee?> GetByIdAsync(int id, CancellationToken ct = default) => _repo.GetByIdAsync(id, ct);

    public Task<bool> DeleteAsync(int id, CancellationToken ct = default) => _repo.DeleteAsync(id, ct);

    public async Task<Employee> CreateAsync(EmployeeCreateDto dto, CancellationToken ct = default)
    {
        var emp = new Employee
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Domain = dto.Domain
        };
        return await _repo.AddAsync(emp, ct);
    }
}
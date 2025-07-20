using EmployeeApi.DTOs;
using EmployeeApi.Models;

namespace EmployeeApi.Services;

public interface IEmployeeService
{
    Task<List<Employee>> GetAllAsync(CancellationToken ct = default);
    Task<Employee?> GetByIdAsync(int id, CancellationToken ct = default);
    Task<Employee> CreateAsync(EmployeeCreateDto dto, CancellationToken ct = default);
    Task<bool> DeleteAsync(int id, CancellationToken ct = default);
}
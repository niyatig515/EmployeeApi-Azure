using EmployeeApi.DTOs;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _service;
    public EmployeesController(IEmployeeService service) => _service = service;

    // GET: api/employees
    [HttpGet]
    public async Task<ActionResult> GetAll(CancellationToken ct)
    {
        var employees = await _service.GetAllAsync(ct);
        return Ok(employees);
    }

    // GET: api/employees/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetById(int id, CancellationToken ct)
    {
        var emp = await _service.GetByIdAsync(id, ct);
        if (emp is null) return NotFound();
        return Ok(emp);
    }

    // POST: api/employees
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] EmployeeCreateDto dto, CancellationToken ct)
    {
        var created = await _service.CreateAsync(dto, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.EmployeeId }, created);
    }

    // DELETE: api/employees/{id}
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id, CancellationToken ct)
    {
        var removed = await _service.DeleteAsync(id, ct);
        if (!removed) return NotFound();
        return NoContent();
    }
}
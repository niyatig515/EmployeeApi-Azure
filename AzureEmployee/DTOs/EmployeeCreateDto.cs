namespace EmployeeApi.DTOs;

public record EmployeeCreateDto(string FirstName, string LastName, string Email, string? Domain);

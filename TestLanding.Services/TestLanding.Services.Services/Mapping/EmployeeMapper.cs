using System.Globalization;
using TestLanding.Domain;
using TestLanding.Domain.ViewModels;

namespace TestLanding.Services.Mapping;

public static class EmployeeMapper
{
    public static EmployeeViewModel? ToView(this Employee? employee) => employee is null
        ? null
        : new EmployeeViewModel
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Patronymic = employee.Patronymic,
            DateOfBirth = employee.DateOfBirth,
            Department = employee.Department,
            Salary = employee.Salary,
            DateOfEmployment = employee.DateOfEmployment,
            ShortName = employee.ShortName,
            DepartmentId = employee.Department.Id
        };

    public static Employee? FromView(this EmployeeViewModel? employee) => employee is null
        ? null
        : new Employee
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Patronymic = employee.Patronymic,
            DateOfBirth = employee.DateOfBirth,
            Salary = employee.Salary,
            DateOfEmployment = employee.DateOfEmployment,
            DepartmentId = employee.Department.Id,
            Department = employee.Department,
        };

    public static IEnumerable<EmployeeViewModel?> ToView(this IEnumerable<Employee?> employee) => employee.Select(ToView);

    public static IEnumerable<Employee?> ToView(this IEnumerable<EmployeeViewModel?> employee) => employee.Select(FromView);

}

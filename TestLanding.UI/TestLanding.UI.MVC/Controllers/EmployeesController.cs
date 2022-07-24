using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestLanding.Domain;
using TestLanding.Domain.ViewModels;
using TestLanding.Interfaces;
using TestLanding.Services.Mapping;

namespace TestLanding.UI.MVC.Controllers;

public class EmployeesController : Controller
{
    private readonly IEmployeesData _EmployeesData;
    private readonly ILogger<EmployeesController> _Logger;

    public EmployeesController(IEmployeesData EmployeesData, ILogger<EmployeesController> Logger)
    {
        _EmployeesData = EmployeesData;
        _Logger = Logger;
    }

    public async Task<IActionResult> Index(string sortOrder)
    {
        ViewBag.IdSortParam = sortOrder == "Id" ? "Id_desc" : "Id";
        ViewBag.LastNameSortParam = sortOrder == "LastName" ? "LastName_desc" : "LastName";
        ViewBag.FirstNameSortParam = sortOrder == "FirstName" ? "FirstName_desc" : "FirstName";
        ViewBag.PatronymicSortParam = sortOrder == "Patronymic" ? "Patronymic_desc" : "Patronymic";
        ViewBag.DepartmentSortParam = sortOrder == "Department" ? "Department_desc" : "Department";
        ViewBag.DateOfBirthSortParam = sortOrder == "DateOfBirth" ? "DateOfBirth_desc" : "DateOfBirth";
        ViewBag.DateOfDepartmentSortParam = sortOrder == "DateOfDepartment" ? "DateOfDepartment_desc" : "DateOfDepartment";
        ViewBag.SalarySortParam = sortOrder == "Salary" ? "Salary_desc" : "Salary";

        var employees = await _EmployeesData.GetAllAsync();

        switch (sortOrder)
        {
            case "Id":
                employees = employees.OrderBy(s => s.Id);
                break;
            case "Id_desc":
                employees = employees.OrderByDescending(s => s.Id);
                break;
            case "LastName":
                employees = employees.OrderBy(s => s.LastName);
                break;
            case "LastName_desc":
                employees = employees.OrderByDescending(s => s.LastName);
                break;
            case "FirstName":
                employees = employees.OrderBy(s => s.FirstName);
                break;
            case "FirstName_desc":
                employees = employees.OrderByDescending(s => s.FirstName);
                break;
            case "Patronymic":
                employees = employees.OrderBy(s => s.Patronymic);
                break;
            case "Patronymic_desc":
                employees = employees.OrderByDescending(s => s.Patronymic);
                break;
            case "Department":
                employees = employees.OrderBy(s => s.Department.Name);
                break;
            case "Department_desc":
                employees = employees.OrderByDescending(s => s.Department.Name);
                break;
            case "DateOfBirth":
                employees = employees.OrderBy(s => s.DateOfBirth);
                break;
            case "DateOfBirth_desc":
                employees = employees.OrderByDescending(s => s.DateOfBirth);
                break;
            case "DateOfDepartment":
                employees = employees.OrderBy(s => s.DateOfEmployment);
                break;
            case "DateOfDepartment_desc":
                employees = employees.OrderByDescending(s => s.DateOfEmployment);
                break;
            case "Salary":
                employees = employees.OrderBy(s => s.Salary);
                break;
            case "Salary_desc":
                employees = employees.OrderByDescending(s => s.Salary);
                break;
            default:
                employees = employees.OrderBy(s => s.Id);
                break;
        }

        return View(employees.ToView().ToList());
    }

    public async Task<IActionResult> Details(int Id)
    {
        var employee = await _EmployeesData.GetByIdAsync(Id);

        if (employee == null)
            return NotFound();

        return View(employee.ToView());
    }

    public IActionResult Create()
    {
        DepartmentDropDownList();
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmployeeViewModel employee)
    {
        var validState = ModelState.Values;
        //if(ModelState.IsValid)
            await _EmployeesData.AddAsync(employee.FromView()!);

        DepartmentDropDownList(employee.DepartmentId);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? Id)
    {
        if (Id is not { } id)
        {
            return View(new EmployeeViewModel());
        }

        var employee = await _EmployeesData.GetByIdAsync(id);
        DepartmentDropDownList(employee!.DepartmentId);

        if (employee is null)
            return NotFound();

        var model = employee.ToView();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EmployeeViewModel Model)
    {
        //if (!ModelState.IsValid) return View(Model);

        var employee = Model.FromView();
        DepartmentDropDownList(Model.DepartmentId);

        if (Model.Id == 0)
        {
            var id = await _EmployeesData.AddAsync(employee!);
            return RedirectToAction(nameof(Details), new { id });
        }

        await _EmployeesData.EditAsync(employee!);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        if (id < 0)
            return BadRequest();

        var employee = await _EmployeesData.GetByIdAsync(id);
        if (employee is null)
            return NotFound();

        var model = employee.ToView();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int Id)
    {
        if (!await _EmployeesData.DeleteAsync(Id))
            return NotFound();

        return RedirectToAction(nameof(Index));
    }


    private void DepartmentDropDownList(object? selectedDepartment = null)
    {
        var departments = _EmployeesData.GetDepartments();
        ViewBag.DepartmentId = new SelectList(departments, "Id", "Name", selectedDepartment);
    }
}

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

    public async Task<IActionResult> Index(SortState sortOrder = SortState.IdAsc)
    {
        var employees = await _EmployeesData.GetAllAsync();

        ViewData["IdSort"] = sortOrder == SortState.IdAsc ? SortState.IdDesc : SortState.IdAsc;
        ViewData["LastNameSort"] = sortOrder == SortState.LastNameAsc ? SortState.LastNameDesc : SortState.LastNameAsc;
        ViewData["FirstNameSort"] = sortOrder == SortState.FirstNameAsc ? SortState.FirstNameDesc : SortState.FirstNameAsc;
        ViewData["PatronymicSort"] = sortOrder == SortState.PatronymicAsc ? SortState.PatronymicDesc : SortState.PatronymicAsc;
        ViewData["DateOfBirthSort"] = sortOrder == SortState.DateOfBirthAsc ? SortState.DateOfBirthDesc : SortState.DateOfBirthAsc;
        ViewData["DepartmentSort"] = sortOrder == SortState.DepartmentAsc ? SortState.DepartmentDesc : SortState.DepartmentAsc;
        ViewData["SalarySort"] = sortOrder == SortState.SalaryAsc ? SortState.SalaryDesc : SortState.SalaryAsc;
        ViewData["DateOfEmploymentSort"] = sortOrder == SortState.DateOfEmploymentAsc ? SortState.DateOfEmploymentDesc : SortState.DateOfEmploymentAsc;

        employees = sortOrder switch
        {
            SortState.IdAsc => employees.OrderBy(s => s.Id),
            SortState.IdDesc => employees.OrderByDescending(s => s.Id),
            SortState.LastNameAsc => employees.OrderBy(s => s.LastName),
            SortState.LastNameDesc => employees.OrderByDescending(s => s.LastName),
            SortState.FirstNameAsc => employees.OrderBy(s => s.FirstName),
            SortState.FirstNameDesc => employees.OrderByDescending(s => s.FirstName),
            SortState.PatronymicAsc => employees.OrderBy(s => s.Patronymic),
            SortState.PatronymicDesc => employees.OrderByDescending(s => s.Patronymic),
            SortState.DateOfBirthAsc => employees.OrderBy(s => s.DateOfBirth),
            SortState.DateOfBirthDesc => employees.OrderByDescending(s => s.DateOfBirth),
            SortState.DepartmentAsc => employees.OrderBy(s => s.Department.Name),
            SortState.DepartmentDesc => employees.OrderByDescending(s => s.Department.Name),
            SortState.SalaryAsc => employees.OrderBy(s => s.Salary),
            SortState.SalaryDesc => employees.OrderByDescending(s => s.Salary),
            SortState.DateOfEmploymentAsc => employees.OrderBy(s => s.DateOfEmployment),
            SortState.DateOfEmploymentDesc => employees.OrderByDescending(s => s.DateOfEmployment),
            _ => employees.OrderBy(s => s.Id),
        };

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

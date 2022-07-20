using Microsoft.AspNetCore.Mvc;
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

    public async Task<IActionResult> Index()
    {
        var employees = await _EmployeesData.GetAllAsync();
        return View(employees.ToView());
    }

    public async Task<IActionResult> Details(int Id)
    {
        var employee = await _EmployeesData.GetByIdAsync(Id);

        if (employee == null)
            return NotFound();

        return View(employee.ToView());
    }

    public IActionResult Create() => View("Edit", new EmployeeViewModel());

    public async Task<IActionResult> Edit(int? Id)
    {
        if (Id is not { } id)
        {
            return View(new EmployeeViewModel());
        }

        var employee = await _EmployeesData.GetByIdAsync(id);
        if (employee is null)
            return NotFound();

        var model = employee.ToView();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EmployeeViewModel Model)
    {
        if (!ModelState.IsValid) return View(Model);

        var employee = Model.FromView();

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

}

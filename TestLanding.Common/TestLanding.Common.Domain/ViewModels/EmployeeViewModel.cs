﻿using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace TestLanding.Domain.ViewModels;

public class EmployeeViewModel : IValidatableObject
{
    [HiddenInput(DisplayValue = false)]
    public int Id { get; set; }

    [Display(Name = "Фамилия")]
    [Required(ErrorMessage = "Фамилия является обязательной!")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина фамилии должна быть от 2 до 30 символов!")]
    [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Ошибка формата строки")]
    public string LastName { get; set; } = null!;

    [Display(Name = "Имя")]
    [Required(ErrorMessage = "Имя является обязательным!")]
    [StringLength(30, MinimumLength = 2, ErrorMessage = "Длина имени должна быть от 2 до 30 символов!")]
    [RegularExpression(@"([А-ЯЁ][а-яё]+)|([A-Z][a-z]+)", ErrorMessage = "Ошибка формата строки")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Отчество")]
    [StringLength(30, ErrorMessage = "Длина отчества должна быть до 30 символов!")]
    [RegularExpression(@"(([А-ЯЁ][а-яё]+)|([A-Z][a-z]+))?", ErrorMessage = "Ошибка формата строки")]
    public string? Patronymic { get; set; }

    [Display(Name = "Отдел")]
    [Required(ErrorMessage = "Название отдела должнен быть указано!")]
    public Department Department { get; set; } = null!;

    [Display(Name = "Id отдела")]
    [Required(ErrorMessage = "Id отдела должнен быть указан!")]
    public int DepartmentId { get; set; }

    [Display(Name = "Зарплата")]
    [Required(ErrorMessage = "Зарплата должна быть указана!")]
    [Range(1, 100000, ErrorMessage = "Зарплата не меньше 1 и не больше 100.000!")]
    [DataType(DataType.Currency)]
    public decimal Salary { get; set; }

    [Display(Name = "Дата устройства")]
    [Required(ErrorMessage = "Дата устройства является обязательной!")]
    [DataType(DataType.Date)]
    public DateTime DateOfEmployment { get; set; } 

    [Display(Name = "Дата рождения")]
    [Required(ErrorMessage = "Дата рождения является обязательной!")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; } 

    [Display(Name = "Фамилия и инициалы")]
    public string? ShortName { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext Context)
    {
        yield return ValidationResult.Success!;
    }
}

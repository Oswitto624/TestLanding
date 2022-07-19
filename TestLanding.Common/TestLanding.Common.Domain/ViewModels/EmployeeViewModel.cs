using System.ComponentModel.DataAnnotations;
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
    [Required(ErrorMessage = "Id отдела должнен быть указан!")]
    public Department Department { get; set; } = null!;

    [Display(Name = "Зарплата")]
    [Required(ErrorMessage = "Зарплата должна быть указана!")]
    [Range(0, 100000, ErrorMessage = "Возраст должен быть в пределах от 18 до 80 лет!")]
    public decimal Salary { get; set; }

    [Display(Name = "Дата устройства")]
    [Required(ErrorMessage = "Дата устройства является обязательной!")]
    public DateTime DateOfEmployment { get; set; }

    [Display(Name = "Дата рождения")]
    [Required(ErrorMessage = "Дата рождения является обязательной!")]
    public DateTime DateOfBirth { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext Context)
    {
        yield return ValidationResult.Success!;
    }
}

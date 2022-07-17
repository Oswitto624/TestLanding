using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TestLanding.Domain.Base;
using TestLanding.Interfaces.Base.Entities;

namespace TestLanding.Domain;

public class Employee : Entity, IOrderedEntity
{
    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string ShortName
    {
        get
        {
            var result = new StringBuilder(LastName);

            if (FirstName is { Length: > 0 } first_name)
                result.Append(" ").Append(first_name[0]).Append(".");

            if (Patronymic is { Length: > 0 } patronymic)
                result.Append(" ").Append(patronymic[0]).Append(".");

            return result.ToString();
        }
    }

    [Required]
    public Department Department { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; }

    [Required]
    public DateOnly DateOfEmployment { get; set; }

    public int Order { get; set; }

    public override string ToString() => $"[{Id}] {Department.Name} {ShortName} {DateOfEmployment}";
}

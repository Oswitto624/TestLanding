using System.ComponentModel.DataAnnotations;
using TestLanding.Interfaces.Base.Entities;

namespace TestLanding.Domain.Base;

public class NamedEntity : Entity, INamedEntity
{
    [Required]
    public string Name { get; set; } = null!;
}

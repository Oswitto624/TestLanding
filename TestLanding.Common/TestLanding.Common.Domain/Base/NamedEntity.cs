using System.ComponentModel.DataAnnotations;
using TestLanding.Domain.Base.Interfaces;

namespace TestLanding.Domain.Base;

public class NamedEntity : Entity, INamedEntity
{
    [Required]
    public string Name { get; set; } = null!;
}

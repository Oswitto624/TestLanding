using TestLanding.Domain.Base;
using TestLanding.Interfaces.Base.Entities;

namespace TestLanding.Domain;

public class Department : Entity, IOrderedEntity
{
    public string DepartmentName { get; set; } = null!;

    public int Order { get; set; }
}

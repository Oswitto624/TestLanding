﻿using Microsoft.EntityFrameworkCore;
using TestLanding.Domain.Base;
using TestLanding.Domain.Base.Interfaces;

namespace TestLanding.Domain;

[Index(nameof(Name), IsUnique = true, Name = "NameIndex")]
public class Department : NamedEntity, IOrderedEntity
{
    public int Order { get; set; }

    public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
}

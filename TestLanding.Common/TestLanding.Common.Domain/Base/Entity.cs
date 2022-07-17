using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestLanding.Interfaces.Base.Entities;

namespace TestLanding.Domain.Base;

public class Entity : IEntity
{
    public int Id { get; set; }
}

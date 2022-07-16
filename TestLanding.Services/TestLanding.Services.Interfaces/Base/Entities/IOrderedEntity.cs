namespace TestLanding.Interfaces.Base.Entities;

public interface IOrderedEntity : IEntity
{
    int Order { get; set; }
}

namespace TestLanding.Domain.Base.Interfaces;

public interface IOrderedEntity : IEntity
{
    int Order { get; set; }
}

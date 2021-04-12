namespace Nacometrical
{
  public interface IEntityFactory <out T> : IFactory <T>
    where T : class, IEntity
  {
    T Create ( IDefinition definition );
  }

  public abstract class BasicEntityFactory <T> : IEntityFactory <T>
    where T : class, IEntity
  {
    public T Create ( )
    {
      throw new System.NotImplementedException ( );
    }

    public T Create ( IDefinition definition )
    {
      throw new System.NotImplementedException ( );
    }
  }
}
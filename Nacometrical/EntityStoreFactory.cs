namespace Nacometrical
{
  public class EntityStoreFactory : IFactory <EntityStore>
  {
    public static EntityStoreFactory Instance => new ( );

    public EntityStore Create ( ) => new ( );
  }
}
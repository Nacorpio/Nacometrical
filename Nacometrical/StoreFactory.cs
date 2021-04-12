namespace Nacometrical
{
  public class StoreFactory <T> : IFactory <Store <T>>
  {
    public static StoreFactory <T> Instance => new ( );

    public Store <T> Create ( ) => new ( );
  }
}
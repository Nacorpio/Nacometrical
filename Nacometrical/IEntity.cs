namespace Nacometrical
{
  public interface IEntity : IUnit, IUnique <ulong>
  {
    void Initialize ( );
    void Destroy ( );
  }
}
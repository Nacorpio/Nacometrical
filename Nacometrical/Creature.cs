namespace Nacometrical
{
  public class Creature : Entity
  {
    public Creature ( ulong id ) : base ( id )
    {
    }

    public Vehicle CurrentVehicle { get; private set; }

    public void EnterVehicle ( Vehicle vehicle )
    {
    }

    public void LeaveVehicle ( )
    {
    }
  }
}
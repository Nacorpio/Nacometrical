namespace Nacometrical
{
  public class VehicleDoorBuilder : VehiclePartBuilder <VehicleDoorBuilder, VehicleDoor>
  {
    public VehicleWindow AttachedWindow { get; private set; }

    public bool IsOpened { get; private set; }
    public bool IsLocked { get; private set; }

    public VehicleDoorBuilder WithAttachedWindow ( VehicleWindow window )
    {
      AttachedWindow = window;
      return this;
    }

    public VehicleDoorBuilder SetOpened ( bool value )
    {
      IsOpened = value;
      return this;
    }

    public VehicleDoorBuilder SetLocked ( bool value )
    {
      IsLocked = value;
      return this;
    }
    
    public override VehicleDoor Build ( byte id )
    {
      var door = base.Build ( id );

      if ( IsOpened )
      {
        door.Open ( );
      }

      if ( IsLocked )
      {
        door.Lock ( );
      }

      if ( AttachedWindow != null )
      {
        door.SetAttachedWindow ( AttachedWindow );
      }

      return door;
    }
  }
}
namespace Nacometrical
{
  public class Vehicle : Entity
  {
    public VehicleSeatMap Seats { get; } = new ( );
    public VehicleDoorMap Doors { get; } = new ( );
    public VehicleWindowMap Windows { get; } = new ( );

    public Vehicle ( ulong id ) : base ( id )
    { }

    public new VehicleDefinition GetDefinition ( ) =>
      base.GetDefinition ( ) as VehicleDefinition;

    public override void Initialize ( )
    {
      base.Initialize ( );

      var definition = GetDefinition ( );

      foreach ( var window in definition.Windows )
      {
        Windows.Create
        (
          ( _ , pb ) => pb
           .WithCommonName ( window.Name )
           .SetOpened ( window.IsOpen )
           .SetBroken ( window.IsBroken )
        );
      }

      foreach ( var door in definition.Doors )
      {
        Doors.Create
        (
          ( _ , pb ) => pb
           .WithCommonName ( door.Name )
           .WithAttachedWindow ( Windows.Get ( door.WindowName ) )
           .SetOpened ( door.IsOpen )
           .SetBroken ( door.IsBroken )
           .SetLocked ( door.IsLocked )
        );
      }
    }
  }
}
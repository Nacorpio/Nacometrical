namespace Nacometrical
{
  public class VehicleLight : VehiclePart
  {
    public VehicleLight ( byte id ) : base ( id )
    { }

    public VehicleLightState State { get; private set; }
    public VehicleLightType Type { get; private set; }

    public bool IsTurnedOn => !IsTurnedOff;
    public bool IsTurnedOff => State == VehicleLightState.Off;

    public void TurnOn ( ) => TryTurnOn ( );
    public void TurnOff ( ) => TryTurnOff ( );

    public bool TryTurnOn ( )
    {
      if ( IsTurnedOn || IsBroken )
      {
        return false;
      }

      SetState ( VehicleLightState.On );
      return true;
    }

    public bool TryTurnOff ( )
    {
      if ( IsTurnedOff || IsBroken )
      {
        return false;
      }

      SetState ( VehicleLightState.Off );
      return true;
    }

    public void SetState ( VehicleLightState state )
    {
      if ( IsBroken ) return;
      State = state;
    }

    public void SetType ( VehicleLightType type )
    {
      Type = type;
    }
  }
}
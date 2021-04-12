namespace Nacometrical
{
  public class VehicleLightMap : VehiclePartMap <VehicleLight , VehicleLightBuilder>
  {
    public void TurnOnAll ( ) => Entries.ForEach ( x => x.TurnOn ( ) );
    public void TurnOffAll ( ) => Entries.ForEach ( x => x.TurnOff ( ) );

    public bool TryGetLight ( string name , out VehicleLight result )
    {
      if ( !PartNameMap.TryGetValue ( name , out var lightId ) )
      {
        result = null;
        return false;
      }

      result = Get ( lightId );
      return true;
    }

    public bool TryGetLight ( byte id , out VehicleLight result )
    {
      if ( !Contains ( id ) )
      {
        result = null;
        return false;
      }
       
      result = Get ( id );
      return true;
    }
  }
}
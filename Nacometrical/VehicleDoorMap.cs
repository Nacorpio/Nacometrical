namespace Nacometrical
{
  public class VehicleDoorMap : VehiclePartMap <VehicleDoor , VehicleDoorBuilder>
  {
    public void OpenAll ( ) =>
      Entries.ForEach ( x => x.Open ( ) );

    public void CloseAll ( ) =>
      Entries.ForEach ( x => x.Close ( ) );

    public bool TryGetDoor ( string name , out VehicleDoor result )
    {
      if ( !PartNameMap.TryGetValue ( name , out var doorId ) )
      {
        result = null;
        return false;
      }

      result = Get ( doorId );
      return true;
    }

    public bool TryGetDoor ( byte id , out VehicleDoor result )
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
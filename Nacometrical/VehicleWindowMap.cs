namespace Nacometrical
{
  public class VehicleWindowMap : VehiclePartMap <VehicleWindow, VehicleWindowBuilder>
  {
    public void CloseAll ( ) =>
      Entries.ForEach ( x => x.Close ( ) );

    public void FixAll ( ) =>
      Entries.ForEach ( x => x.Fix ( ) );

    public bool TryGetWindow ( string name , out VehicleWindow result )
    {
      if ( !PartNameMap.TryGetValue ( name , out var windowId ) )
      {
        result = null;
        return false;
      }

      result = Get ( windowId );
      return true;
    }

    public bool TryGetWindow ( byte id , out VehicleWindow result )
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
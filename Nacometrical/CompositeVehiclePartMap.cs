using System.Collections.Generic;
using System.Linq;

namespace Nacometrical
{
  public class CompositeVehiclePartMap
  {
    private readonly Dictionary <int , IVehiclePartMap> _maps = new ( );

    public CompositeVehiclePartMap ( )
    {
      void _Map <TMap> ( )
        where TMap : IVehiclePartMap , new ( )
      {
        var mapType = typeof ( TMap );
        var mapValueType = mapType.GenericTypeArguments.FirstOrDefault ( );

        if ( mapValueType == null )
        {
          return;
        }

        _maps.Add ( mapValueType.GetHashCode ( ) , new TMap ( ) );
      }

      _Map <VehicleWindowMap> ( );
      _Map <VehicleDoorMap> ( );
      _Map <VehicleLightMap> ( );
    }

    public void AddPart <TPart> ( TPart part )
      where TPart : IVehiclePart
    {

    }
  }
}
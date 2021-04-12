using System.Collections.Generic;

namespace Nacometrical
{
  public interface IImmutableVehiclePartMap <TPart , TPartBuilder> : IVehiclePartMap
    where TPart : VehiclePart
    where TPartBuilder : VehiclePartBuilder <TPartBuilder , TPart>
  {
    TPart Get ( byte partId );
    TPart Get ( string partName );

    bool Contains ( byte partId );
    bool Contains ( string partName );
    bool Contains ( TPart part );

    bool ContainsMany ( IEnumerable <byte> partIds );
    bool ContainsMany ( IEnumerable <string> partNames );
    bool ContainsMany ( IEnumerable <TPart> parts );
  }
}
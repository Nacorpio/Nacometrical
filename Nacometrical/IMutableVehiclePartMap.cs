using System;
using System.Collections.Generic;

namespace Nacometrical
{
  public interface IMutableVehiclePartMap <TPart , TPartBuilder> 
    : IImmutableVehiclePartMap <TPart , TPartBuilder>
    where TPart : VehiclePart
    where TPartBuilder : VehiclePartBuilder <TPartBuilder , TPart>
  {
    TPart Create ( Action <byte , TPartBuilder> buildFunc );
    IEnumerable <TPart> CreateMany ( int count , Action <byte , TPartBuilder> buildFunc );

    bool Remove ( byte partId );
    bool Remove ( string partName );
    bool Remove ( TPart part );

    int RemoveMany ( IEnumerable <byte> partIds );
    int RemoveMany ( IEnumerable <string> partNames );
    int RemoveMany ( IEnumerable <TPart> parts );

    void Clear ( );
  }
}
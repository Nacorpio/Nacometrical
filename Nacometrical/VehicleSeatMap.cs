using System.Collections.Generic;
using System.Linq;

namespace Nacometrical
{
  public class VehicleSeatMap : VehiclePartMap <VehicleSeat , VehicleSeatBuilder>
  {
    public VehicleSeat CreateDriverSeat ( ) =>
      Create
      (
        ( _ , x ) => x
         .WithType ( VehicleSeatType.Driver )
      );

    public VehicleSeat CreatePassengerSeat ( ) =>
      Create
      (
        ( _ , x ) => x
         .WithType ( VehicleSeatType.Passenger )
      );


    public VehicleSeat GetOccupiedSeat ( Creature occupant ) =>
      GetOccupiedSeats ( )
       .FirstOrDefault ( x => x.GetOccupant ( ).Equals ( occupant ) );


    public VehicleSeat GetFreeSeat ( ) =>
      GetFreeSeats ( ).FirstOrDefault ( );

    public VehicleSeat GetFreeSeat ( VehicleSeatType type ) =>
      GetFreeSeats ( ).FirstOrDefault ( x => x.Type == type );


    public IEnumerable <VehicleSeat> GetFreeSeats ( VehicleSeatType type ) =>
      GetFreeSeats ( )
       .Where ( x => x.Type == type );

    public IEnumerable <VehicleSeat> GetOccupiedSeats ( VehicleSeatType type ) =>
      GetOccupiedSeats ( )
       .Where ( x => x.Type == type );


    public IEnumerable <VehicleSeat> GetFreeSeats ( ) =>
      Entries.Where ( x => x.IsFree );

    public IEnumerable <VehicleSeat> GetOccupiedSeats ( ) =>
      Entries.Where ( x => x.IsOccupied );


    public IEnumerable <Creature> GetOccupants ( ) =>
      Entries.Select ( x => x.GetOccupant ( ) );


    public bool TryGetFreeSeat ( VehicleSeatType type , out VehicleSeat result )
    {
      var freeSeat = GetFreeSeat ( type );

      if ( freeSeat == null )
      {
        result = null;
        return false;
      }

      result = freeSeat;
      return true;
    }

    public bool TryGetFreeSeat ( out VehicleSeat result )
    {
      var freeSeat = GetFreeSeat ( );

      if ( freeSeat == null )
      {
        result = null;
        return false;
      }

      result = freeSeat;
      return true;
    }
  }
}
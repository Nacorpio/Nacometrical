using System.Collections.Generic;
using System.Linq;

namespace Nacometrical
{
  public class VehicleSeatMap
  {
    private readonly List <VehicleSeat> _seats = new ( byte.MaxValue );

    public byte CreateSeat ( VehicleSeatType type )
    {
      var id = (byte) _seats.Count;
      _seats.Add ( new VehicleSeat ( id, type ) );

      return id;
    }

    public void Kick ( Creature creature ) => creature.LeaveVehicle ( );

    public void KickMany ( IEnumerable <Creature> creatures )
    {
      foreach ( var creature in creatures )
      {
        Kick ( creature );
      }
    }

    public void KickAll ( )
    {
      foreach ( var seat in _seats.Where ( x => x.IsOccupied ) )
      {
        seat.GetOccupant ( ).LeaveVehicle ( );
      }
    }

    public VehicleSeat FindUsedSeat ( Creature creature ) => _seats
     .FirstOrDefault ( x => x.GetOccupant ( ).Id == creature.Id );

    public VehicleSeat FindFreeSeat ( VehicleSeatType type ) => _seats
     .FirstOrDefault ( x => x.Type == type && !x.IsOccupied );

    public VehicleSeat FindFreeSeat ( ) => _seats
     .FirstOrDefault ( x => !x.IsOccupied );

    public bool HasUsedSeat ( Creature creature ) => _seats
     .Any ( x => x.GetOccupant ( ).Id.Equals ( creature.Id ) );

    public bool HasFreeSeat ( VehicleSeatType type ) => _seats
     .Any ( x => x.Type == type && !x.IsOccupied );

    public bool HasFreeSeat ( ) => _seats
     .Any ( x => !x.IsOccupied );

    public byte CreateDriverSeat ( ) => CreateSeat ( VehicleSeatType.Driver );
    public byte CreatePassengerSeat ( ) => CreateSeat ( VehicleSeatType.Passenger );

    public VehicleSeat GetDriverSeat ( int index ) => GetDriverSeats ( ) [ index ];
    public VehicleSeat GetPassengerSeat ( int index ) => GetPassengerSeats ( ) [ index ];

    public VehicleSeat Get ( byte seatId ) => _seats
     .FirstOrDefault ( x => x.Id == seatId );

    public IReadOnlyList <VehicleSeat> GetDriverSeats ( ) => _seats
     .Where ( x => x.Type == VehicleSeatType.Driver )
     .OrderBy ( x => x.Id )
     .ToList ( );

    public IReadOnlyList <VehicleSeat> GetPassengerSeats ( ) => _seats
     .Where ( x => x.Type == VehicleSeatType.Passenger )
     .OrderBy ( x => x.Id )
     .ToList ( );
  }
}
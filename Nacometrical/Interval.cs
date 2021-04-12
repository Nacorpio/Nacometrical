using System.Collections.Generic;
using System.Linq;

namespace Nacometrical
{
  public partial class Interval
  {
    public static Interval Zero => new ( 0, 0 );

    public double Minimum { get; }
    public double Maximum { get; }

    public double Length => Maximum - Minimum;

    public Interval ( double min, double max )
    {
      Minimum = min;
      Maximum = max;
    }
    
    public (double, double) GetDeltas ( double value )
    {
      return ( value - Minimum, Maximum - value );
    }

    public double Contain ( double value )
    {
      if ( value < Minimum )
      {
        value = Minimum;
      }

      if ( value > Maximum )
      {
        value = Maximum;
      }

      return value;
    }

    public Interval Contain ( Interval interval )
    {
      return new ( Contain ( interval.Minimum ), Contain ( interval.Maximum ) );
    }
  }

  public partial class Interval
  {
    public bool Intersects ( Interval interval )
    {
      return Contains ( interval.Minimum ) || Contains ( interval.Maximum );
    }

    public bool IntersectsMany ( IEnumerable <Interval> intervals )
    {
      return intervals.All ( Intersects );
    }

    public bool Contains ( Interval interval )
    {
      return Contains ( interval.Minimum ) && Contains ( interval.Maximum );
    }

    public bool Contains ( double value )
    {
      return value >= Minimum && value <= Maximum;
    }

    public bool ContainsMany ( IEnumerable <double> values )
    {
      return values.All ( Contains );
    }

    public bool ContainsAny ( IEnumerable <double> values )
    {
      return values.Any ( Contains );
    }
  }
}
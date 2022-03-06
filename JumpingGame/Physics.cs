namespace JumpingPlatformGame {

	public static class Expansions
	{
		public static Length Meters(this int d)
		{
			return new Length { Meters = d };
		}
		public static Time Seconds(this double d)
		{
			return new Time { Seconds = d };
		}
		public static Velocity MeterPerSeconds(this int d)
		{
			return new Velocity { Value = d, actual = d };
		}
		public static Velocity MeterPerSeconds(this double d)
		{
			return new Velocity { Value = d, actual = d };
		}
	}

	class WorldPoint
	{
		public Length X;
		public Length Y;
	}
	public class Length
	{
		public double Meters;
		public static implicit operator Length(double value)
		{
			return new Length { Meters = value };
		}
	}
	public class Move
	{
		public Length LowerBound;
		public Length UpperBound;
		public Velocity Speed;		
	}
	 
	public class Time
	{
		public double Seconds;
		
	}
	public class Velocity
	{
		public double actual;
		public double Value;
	}

	public static class Physics
	{
		public static void Move(Time sec, Velocity speed, double lower_bound, double upper_bound, Length entity_position, bool jump)
		{
			double move_amount = sec.Seconds * speed.actual;
			var new_position = entity_position.Meters + move_amount;

			if (new_position < upper_bound && new_position > lower_bound)
			{
				entity_position.Meters += move_amount;
				return;
			}
			else
			{
				if (new_position >= upper_bound)
				{
					entity_position.Meters = upper_bound;
					speed.actual = -speed.actual;
				}
				else
				{
					entity_position.Meters = lower_bound;
					speed.actual = -speed.actual;
					if (jump) speed.actual= 0;
				}
			}
		}
	}

	
}
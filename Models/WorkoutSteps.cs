namespace ZWOSharp.Models
{

    public class SteadyState : WorkoutStep
    {
        public double Duration { get; set; } = -1;
        public double Power { get; set; } = -1;
        public double PowerLow { get; set; } = -1;
        public double PowerHigh { get; set; } = -1;
        public double Cadence { get; set; } = -1;
        public override string Type => "SteadyState";
    }

    public class IntervalsT : WorkoutStep
    {
        public int Repeat { get; set; } = -1;
        public double OnDuration { get; set; } = -1;
        public double OnPower { get; set; } = -1;
        public double OffDuration { get; set; } = -1;
        public double OffPower { get; set; } = -1;
        public override string Type => "IntervalsT";
    }

    public class FreeRide : WorkoutStep
    {
        public double Duration { get; set; } = -1;
        public int FlatRoad { get; set; } = -1;
        public override string Type => "FreeRide";
    }

    public class Ramp : WorkoutStep
    {
        public double Duration { get; set; } = -1;
        public double PowerLow { get; set; } = -1;
        public double PowerHigh { get; set; } = -1;
        public override string Type => "Ramp";
    }

    public class WarmUp : WorkoutStep
    {
        public double Duration { get; set; } = -1;
        public double PowerLow { get; set; } = -1;
        public double PowerHigh { get; set; } = -1;
        public double Cadence { get; set; } = -1;
        public double CadenceResting { get; set; } = -1;
        public override string Type => "WarmUp";
    }

    public class Cooldown : WorkoutStep
    {
        public double Duration { get; set; } = -1;
        public double PowerLow { get; set; } = -1;
        public double PowerHigh { get; set; } = -1;
        public override string Type => "Cooldown";
    }
}

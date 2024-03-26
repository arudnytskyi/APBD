using tut2.caution;

namespace tut2.containers;

public class GasContainer(
    int height,
    double tareWeight,
    int depth,
    string serialNumber,
    double maxPayload,
    double pressure)
    : Container(height, tareWeight, depth, serialNumber, maxPayload), IHazardNotifier
{
    public double Pressure { get; private set; } = pressure;

    public override void LoadCargo(double mass)
    {
        if (mass > MaxPayload)
        {
            throw new OverfillException($"Attempted to load {mass} kg exceeds the gas container's maximum payload of {MaxPayload} kg.");
        }
        
        CargoMass = mass;
    }

    public override void EmptyCargo()
    {
        CargoMass *= 0.05;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazardous condition detected in gas container {message}.");
    }
}

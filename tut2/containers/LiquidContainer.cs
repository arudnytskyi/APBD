using tut2.caution;

namespace tut2.containers;

public class LiquidContainer(
    int height,
    double tareWeight,
    int depth,
    string serialNumber,
    double maxPayload,
    bool isHazardous)
    : Container(height, tareWeight, depth, serialNumber, maxPayload), IHazardNotifier
{
    private bool IsHazardous { get; set; } = isHazardous;

    public override void LoadCargo(double mass)
    {
        double allowedCapacity = IsHazardous ? MaxPayload * 0.5 : MaxPayload * 0.9;
        if (mass > allowedCapacity)
        {
            throw new OverfillException($"Attempting to overfill a liquid container {SerialNumber}. Max allowed mass: {allowedCapacity}, attempted load mass: {mass}.");
        }
        CargoMass = mass;
    }

    public override void EmptyCargo()
    {
        CargoMass = 0;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"Hazard Notification for {SerialNumber}: {message}");
    }
}
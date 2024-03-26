using tut2.caution;

namespace tut2.containers;

public class RefrigeratedContainer(
    int height,
    double tareWeight,
    int depth,
    string serialNumber,
    double maximumPayload,
    string productType,
    double temperature)
    : Container(height, tareWeight, depth, serialNumber, maximumPayload)
{
    public string ProductType { get; private set; } = productType;
    public double Temperature { get; private set; } = temperature;

    public override void LoadCargo(double mass)
    {
        if (mass > MaxPayload)
            throw new OverfillException("Cargo mass exceeds the container's maximum payload.");
        CargoMass = mass;
    }

    public override void EmptyCargo()
    {
        CargoMass = 0;
    }
}

namespace tut2.containers;

public abstract class Container(double height, double tareWeight, int depth, string serialNumber, double maxPayload)
{
    public double CargoMass { get; protected set; }
    public double Height { get; private set; } = height;
    public double TareWeight { get; private set; } = tareWeight;
    public int Depth { get; private set; } = depth;
    protected string SerialNumber { get; private set; } = serialNumber;
    protected internal double MaxPayload { get; private set; } = maxPayload;

    public abstract void LoadCargo(double mass);
    public abstract void EmptyCargo();
}
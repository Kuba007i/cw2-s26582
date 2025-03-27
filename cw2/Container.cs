namespace cw2;

public abstract class Container
{
    private static int counter = 1;
    public string SerialNumber { get; private set; }
    public double CargoWeight { get; protected set; }
    public double Height { get; protected set; }
    public double Depth { get; protected set; }
    public double OwnWeight { get; protected set; }
    public double MaxCapacity { get; protected set; }

    protected Container(string type, double height, double depth, double ownWeight, double maxCapacity)
    {
        SerialNumber = $"KON-{type}-{counter++}";
        Height = height;
        Depth = depth;
        OwnWeight = ownWeight;
        MaxCapacity = maxCapacity;
    }

    public abstract void LoadCargo(double weight);
    public abstract void Unload();
    public override string ToString() => $"{SerialNumber} (Load: {CargoWeight}kg / Max: {MaxCapacity}kg)";
}

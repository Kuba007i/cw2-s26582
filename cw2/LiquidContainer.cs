namespace cw2;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; private set; }

    public LiquidContainer(double height, double depth, double ownWeight, double maxCapacity, bool isHazardous)
        : base("L", height, depth, ownWeight, maxCapacity)
    {
        IsHazardous = isHazardous;
    }

    public override void LoadCargo(double weight)
    {
        double limit = IsHazardous ? 0.5 : 0.9;
        if (weight > MaxCapacity * limit)
        {
            NotifyHazard($"Próba załadunku zbyt dużego ładunku do kontenera {SerialNumber}.");
            throw new OverfillException($"Nie można załadować {weight}kg do kontenera {SerialNumber}");
        }
        CargoWeight = weight;
    }

    public override void Unload()
    {
        CargoWeight = 0;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[HAZARD] {message}");
    }
}

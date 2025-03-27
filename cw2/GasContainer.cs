namespace cw2;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; private set; }

    public GasContainer(double height, double depth, double ownWeight, double maxCapacity, double pressure)
        : base("G", height, depth, ownWeight, maxCapacity)
    {
        Pressure = pressure;
    }

    public override void LoadCargo(double weight)
    {
        if (weight > MaxCapacity)
        {
            NotifyHazard($"Próba przepełnienia kontenera {SerialNumber}");
            throw new OverfillException($"Ładunek {weight}kg przekracza pojemność {MaxCapacity}kg kontenera.");
        }
        CargoWeight = weight;
    }

    public override void Unload()
    {
        CargoWeight *= 0.05; // zostaje 5%
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[HAZARD] {message}");
    }
}

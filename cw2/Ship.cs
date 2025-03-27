namespace cw2;

public class Ship
{
    public string Name { get; private set; }
    public double MaxSpeed { get; private set; }
    public int MaxContainerCount { get; private set; }
    public double MaxWeightTons { get; private set; }

    private List<Container> containers = new List<Container>();

    public Ship(string name, double maxSpeed, int maxCount, double maxWeightTons)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxCount;
        MaxWeightTons = maxWeightTons;
    }

    public bool AddContainer(Container container)
    {
        if (containers.Count >= MaxContainerCount)
        {
            Console.WriteLine("Przekroczono maksymalną liczbę kontenerów.");
            return false;
        }

        double totalWeight = containers.Sum(c => c.CargoWeight + c.OwnWeight) + container.CargoWeight + container.OwnWeight;
        if (totalWeight > MaxWeightTons * 1000) // tony -> kg
        {
            Console.WriteLine("Przekroczono maksymalną wagę statku.");
            return false;
        }

        containers.Add(container);
        return true;
    }

    public void AddContainers(List<Container> list)
    {
        foreach (var c in list)
            AddContainer(c);
    }

    public bool RemoveContainer(string serialNumber)
    {
        var container = containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
            return false;

        containers.Remove(container);
        return true;
    }

    public bool ReplaceContainer(string serialNumber, Container newContainer)
    {
        int index = containers.FindIndex(c => c.SerialNumber == serialNumber);
        if (index == -1)
            return false;

        containers[index] = newContainer;
        return true;
    }

    public bool TransferContainer(string serialNumber, Ship otherShip)
    {
        var container = containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null)
            return false;

        if (otherShip.AddContainer(container))
        {
            containers.Remove(container);
            return true;
        }

        return false;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Statek: {Name} (MaxSpeed: {MaxSpeed} knots, MaxContainers: {MaxContainerCount}, MaxWeight: {MaxWeightTons}t)");
        Console.WriteLine($"Kontenery ({containers.Count}):");
        foreach (var c in containers)
            Console.WriteLine($" - {c}");
    }

    public List<Container> GetContainers() => containers;
}

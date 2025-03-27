namespace cw2;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; private set; }
    public double Temperature { get; private set; }
    public double RequiredTemperature { get; private set; }

    public RefrigeratedContainer(double height, double depth, double ownWeight, double maxCapacity,
        string productType, double temperature, double requiredTemp)
        : base("C", height, depth, ownWeight, maxCapacity)
    {
        ProductType = productType;
        Temperature = temperature;
        RequiredTemperature = requiredTemp;

        if (Temperature < RequiredTemperature)
            throw new Exception($"Temperatura kontenera {SerialNumber} jest zbyt niska dla produktu {ProductType}.");
    }

    public override void LoadCargo(double weight)
    {
        if (weight > MaxCapacity)
            throw new OverfillException($"Za duży ładunek do kontenera {SerialNumber}");
        CargoWeight = weight;
    }

    public override void Unload()
    {
        CargoWeight = 0;
    }
}

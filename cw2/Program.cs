namespace cw2;

class Program
{
    static void Main(string[] args)
    {
        Ship ship1 = new Ship("Evergreen", 20, 5, 50); // 50 ton

        var liquid = new LiquidContainer(260, 600, 3000, 10000, false);
        var gas = new GasContainer(250, 500, 2500, 9000, 8);
        var fridge = new RefrigeratedContainer(270, 700, 3500, 9500, "Banany", 10, 8);

        try
        {
            liquid.LoadCargo(8000); // OK - 90%
            gas.LoadCargo(8800);    // OK
            fridge.LoadCargo(9000); // OK
        }
        catch (OverfillException ex)
        {
            Console.WriteLine($"Błąd: {ex.Message}");
        }

        ship1.AddContainer(liquid);
        ship1.AddContainer(gas);
        ship1.AddContainer(fridge);

        ship1.PrintInfo();

        // Rozładunek
        gas.Unload();
        Console.WriteLine($"Po rozładunku gazu: {gas}");

        // Zamiana kontenera
        var newLiquid = new LiquidContainer(260, 600, 3000, 10000, true);
        try
        {
            newLiquid.LoadCargo(6000); // przekroczy 50% => błąd
        }
        catch (OverfillException ex)
        {
            Console.WriteLine($"Błąd przy ładowaniu niebezpiecznego płynu: {ex.Message}");
        }

        // Transfer między statkami
        Ship ship2 = new Ship("Maersk", 25, 10, 100);
        bool moved = ship1.TransferContainer(liquid.SerialNumber, ship2);
        Console.WriteLine(moved ? "Przeniesiono kontener." : "Nie udało się przenieść kontenera.");

        ship1.PrintInfo();
        ship2.PrintInfo();
    }
}

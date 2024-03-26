using tut2.caution;
using tut2.containers;

try
{
    LiquidContainer milkContainer = new LiquidContainer(100, 220, 200, "KON-L-1", 1000, false);
    milkContainer.LoadCargo(800);
    Console.WriteLine($"Milk container loaded with {milkContainer.CargoMass} kg of cargo.");

    LiquidContainer fuelContainer = new LiquidContainer(100, 220, 200, "KON-L-2", 1000, true);
    try
    {
        fuelContainer.LoadCargo(600);
    }
    catch (OverfillException)
    {
        Console.WriteLine("Failed to load fuel container: cargo mass exceeds allowed limit for hazardous materials.");
    }
    
    
    RefrigeratedContainer bananaContainer = new RefrigeratedContainer(100, 220, 200, "KON-C-1", 1000, "Bananas", 5);
    bananaContainer.LoadCargo(900); 
    Console.WriteLine($"Banana container loaded with {bananaContainer.CargoMass} kg of cargo.");

    
    GasContainer heliumContainer = new GasContainer(100, 220, 200, "KON-G-1", 1000, 1.5);
    heliumContainer.LoadCargo(950);
    Console.WriteLine($"Helium container loaded with {heliumContainer.CargoMass} kg of cargo. Remaining after emptying: {heliumContainer.MaxPayload * 0.05} kg");
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}
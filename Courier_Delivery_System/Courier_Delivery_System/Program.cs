using System;

namespace Courier_Delivery_System;

public class Program
{
    public static void Main()
    {
        int menuChoice = 0;
        int counter = 0;

        // Main collection holding all shipments
        Registry<Shipment> registry = new Registry<Shipment>();

        while (menuChoice != 5)
        {
            Console.WriteLine("\nMENU:");
            Console.WriteLine("----------------------------");
            Console.WriteLine("[1]-Create shipment");
            Console.WriteLine("[2]-Show all shipments");
            Console.WriteLine("[3]-Update shipment status");
            Console.WriteLine("[4]-Delete shipment");
            Console.WriteLine("[5]-Exit");
            Console.WriteLine("----------------------------");
            Console.Write("Choice: ");

            // Avoid crashing if user enters non-numeric input
            if (!int.TryParse(Console.ReadLine(), out menuChoice))
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            switch (menuChoice)
            {
                case 1:
                    Console.WriteLine("CREATE SHIPMENT");
                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Options: [1-Standard shipment] or [2-Express shipment]");
                    Console.Write("Choice: ");

                    if (!int.TryParse(Console.ReadLine(), out int typeChoice))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    Console.WriteLine("----------------------------");

                    if (typeChoice == 1) // Standard shipment
                    {
                        Console.Write("Enter recipient name: ");
                        string recipientName = Console.ReadLine();

                        while (string.IsNullOrWhiteSpace(recipientName))
                        {
                            Console.Write("Input cannot be empty! Try again: ");
                            recipientName = Console.ReadLine();
                        }

                        recipientName = recipientName.Trim();

                        Console.WriteLine("----------------------------");
                        Console.Write("Enter shipment weight: ");

                        if (!double.TryParse(Console.ReadLine(), out double weight))
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }
                        Console.WriteLine("----------------------------");

                        try
                        {
                            Shipment standardShipment = new StandardShipment(counter + 1, recipientName, weight, ShipmentStatus.Created);
                            counter++; // Increment only if creation succeeds
                            registry.AddElement(standardShipment);
                            Console.WriteLine("Shipment created!");
                        }

                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }

                    else if (typeChoice == 2) // Express shipment
                    {
                        Console.Write("Enter recipient name: ");
                        string recipientName = Console.ReadLine();

                        while (string.IsNullOrWhiteSpace(recipientName))
                        {
                            Console.Write("Input cannot be empty! Try again: ");
                            recipientName = Console.ReadLine();
                        }

                        recipientName = recipientName.Trim();

                        Console.WriteLine("----------------------------");
                        Console.Write("Enter shipment weight: ");

                        if (!double.TryParse(Console.ReadLine(), out double weight))
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }

                        Console.WriteLine("----------------------------");
                        Console.Write("Enter insurance value (0 for no insurance): ");

                        if (!double.TryParse(Console.ReadLine(), out double insurance))
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }

                        Console.WriteLine("----------------------------");

                        try
                        {
                            ExpressShipment expressShipment = new ExpressShipment(counter + 1, recipientName, weight, ShipmentStatus.Created);

                            // Apply insurance only if user entered a non-zero value
                            if (insurance != 0)
                            {
                                IInsurable insurable = expressShipment;
                                insurable.Insure(insurance);
                            }

                            counter++;
                            registry.AddElement(expressShipment);
                            Console.WriteLine("Shipment created!");
                        }

                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                    }

                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                    break;

                case 2:
                    Console.WriteLine("----------------------------");
                    registry.DisplayAll();
                    break;

                case 3:
                    Console.WriteLine("----------------------------");
                    Console.Write("Enter shipment number: ");

                    if (!int.TryParse(Console.ReadLine(), out int shipmentNumber))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    // Check if shipment exists before asking for the new status
                    Shipment shipmentToUpdate = registry.Find(p => p.ShipmentNumber == shipmentNumber);

                    if (shipmentToUpdate == null)
                    {
                        Console.WriteLine("Shipment with that number does not exist!");
                        break;
                    }

                    Console.WriteLine("----------------------------");
                    Console.WriteLine("Choose new status [1-InTransit] or [2-Delivered] or [3-Cancelled]");
                    Console.Write("Choice: ");

                    if (!int.TryParse(Console.ReadLine(), out int statusChoice))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    if (statusChoice == 1)
                        shipmentToUpdate.ChangeStatus(ShipmentStatus.InTransit);
                    else if (statusChoice == 2)
                        shipmentToUpdate.ChangeStatus(ShipmentStatus.Delivered);
                    else if (statusChoice == 3)
                        shipmentToUpdate.ChangeStatus(ShipmentStatus.Cancelled);
                    else
                        Console.WriteLine("Invalid input!");
                    break;

                case 4:
                    Console.WriteLine("----------------------------");
                    Console.Write("Enter shipment number to delete: ");

                    if (!int.TryParse(Console.ReadLine(), out int deleteNumber))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    Console.WriteLine("----------------------------");

                    // Find and remove the shipment from the registry
                    Shipment shipmentToDelete = registry.Find(p => p.ShipmentNumber == deleteNumber);

                    if (shipmentToDelete != null && registry.ContainsElement(shipmentToDelete))
                    {
                        registry.RemoveElement(shipmentToDelete);
                        Console.WriteLine($"Shipment #{deleteNumber} has been deleted!");
                    }
                    else
                    {
                        Console.WriteLine("Shipment with that number does not exist!");
                    }
                    break;

                case 5:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid input!");
                    break;
            }
        }
    }
}
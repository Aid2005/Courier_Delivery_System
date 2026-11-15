using System;

namespace Courier_Delivery_System;

public abstract class Shipment
{
    // Shipment properties
    public int ShipmentNumber { get; set; }
    public string RecipientName { get; set; }
    public double Weight { get; set; }
    public ShipmentStatus Status { get; set; }

    public Shipment(int shipmentNumber, string recipientName, double weight, ShipmentStatus status)
    {
        ShipmentNumber = shipmentNumber;
        RecipientName = recipientName;
        Weight = weight;
        Status = status;
    }

    // Implemented in StandardShipment and ExpressShipment
    public abstract double CalculatePrice();

    public void DisplayInfo()
    {
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        return $"Shipment number: {ShipmentNumber} | Recipient name: {RecipientName} | Shipment weight: {Weight} | Shipment status: {Status} | Price: {CalculatePrice()}";
    }

    public void ChangeStatus(ShipmentStatus newStatus)
    {
        // Check if the requested status transition is valid
        bool isAllowedTransition = (Status == ShipmentStatus.Created && newStatus == ShipmentStatus.InTransit) ||
                                   (Status == ShipmentStatus.InTransit && newStatus == ShipmentStatus.Delivered) ||
                                   (Status == ShipmentStatus.Created && newStatus == ShipmentStatus.Cancelled);

        if (isAllowedTransition)
        {
            Status = newStatus;
            Console.WriteLine($"Shipment #{ShipmentNumber} status changed to {Status}!");
        }
        else
        {
            Console.WriteLine("Status change is not allowed!");
        }
    }
}
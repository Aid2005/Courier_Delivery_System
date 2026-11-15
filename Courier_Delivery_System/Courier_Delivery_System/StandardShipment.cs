using System;

namespace Courier_Delivery_System;

public class StandardShipment : Shipment
{
    // Pricing rates for standard delivery
    private double BasePrice = 5.0;
    private double PricePerKg = 1.0;

    public StandardShipment(int shipmentNumber, string recipientName, double weight, ShipmentStatus status)
        : base(shipmentNumber, recipientName, weight, status) { }

    // Calculate total price based on weight
    public override double CalculatePrice()
    {
        return BasePrice + (PricePerKg * Weight);
    }

    public override string ToString()
    {
        return $"[Standard shipment] {base.ToString()}";
    }
}
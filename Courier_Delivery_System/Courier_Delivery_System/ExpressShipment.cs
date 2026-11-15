using System;

namespace Courier_Delivery_System;

public class ExpressShipment : Shipment, IInsurable
{
    // Pricing rates and insurance details
    private double BasePrice = 10.0;
    private double PricePerKg = 2.0;
    private double InsuranceRate = 0.2;
    private double DeclaredValue;

    public ExpressShipment(int shipmentNumber, string recipientName, double weight, ShipmentStatus status)
        : base(shipmentNumber, recipientName, weight, status) { }

    // Calculate total price including weight and insurance
    public override double CalculatePrice()
    {
        return BasePrice + (PricePerKg * Weight) + (DeclaredValue * InsuranceRate);
    }

    // Set declared value for insurance
    void IInsurable.Insure(double value)
    {
        if (value < 0)
            throw new ArgumentException("Value must be positive!");
        else
            DeclaredValue = value;
    }

    // Calculate insurance cost
    double IInsurable.CalculateInsurance()
    {
        return DeclaredValue * InsuranceRate;
    }

    public override string ToString()
    {
        return $"[Express shipment] {base.ToString()}";
    }
}
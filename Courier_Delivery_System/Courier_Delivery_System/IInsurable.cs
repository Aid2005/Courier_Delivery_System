using System;

namespace Courier_Delivery_System;

// Contract for shipments that can be insured
public interface IInsurable
{
    public void Insure(double value);

    public double CalculateInsurance();
}
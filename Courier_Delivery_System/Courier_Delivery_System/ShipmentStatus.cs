using System;

namespace Courier_Delivery_System;

// Shipment lifecycle states
public enum ShipmentStatus
{
    Created,
    InTransit,
    Delivered,
    Cancelled
}
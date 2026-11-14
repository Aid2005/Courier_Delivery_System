using System;

namespace Courier_Delivery_System;

public interface IOsigurljivo
{
    public void Osiguraj(double vrijednost);

    public double IzracunajOsiguranje();
}
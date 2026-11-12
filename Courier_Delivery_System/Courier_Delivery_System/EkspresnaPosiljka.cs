using System;

namespace Courier_Delivery_System;

public class EkspresnaPosiljka : Posiljka
{
    public EkspresnaPosiljka(int _brojPosiljke, string _imePrimaoca, double _tezina, StatusPosiljke _status) : base(_brojPosiljke, _imePrimaoca, _tezina, _status) { }

    public override double IzracunajCjenu() { return 2.1; }
    
}
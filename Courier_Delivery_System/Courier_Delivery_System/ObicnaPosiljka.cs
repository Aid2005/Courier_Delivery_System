using System;

namespace Courier_Delivery_System;

public class ObicnaPosiljka : Posiljka
{
    private double OsnovnaCijena = 5.0;
    private double CijenaPoKilogramu = 1.0;
    public ObicnaPosiljka(int _brojPosiljke, string _imePrimaoca, double _tezina, StatusPosiljke _status) : base(_brojPosiljke, _imePrimaoca, _tezina, _status) { }

    public override double IzracunajCjenu()
    {
        return OsnovnaCijena + (CijenaPoKilogramu * Tezina);
    }

    public override string ToString()
    {
        return $"[Obična pošiljka] {base.ToString()}";
        ;
    }
}
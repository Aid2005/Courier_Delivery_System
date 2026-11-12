using System;

namespace Courier_Delivery_System;

public abstract class Posiljka
{
    public int BrojPosiljke { get; set; }
    public string ImePrimaoca { get; set; }
    public double Tezina { get; set; }
    public StatusPosiljke Status {  get; set; }

    public Posiljka(int _brojPosiljke, string _imePrimaoca,double _tezina, StatusPosiljke _status )
    {
        BrojPosiljke = _brojPosiljke;
        ImePrimaoca = _imePrimaoca;
        Tezina = _tezina;
        Status = _status;
    }

    public abstract double IzracunajCjenu();

    public void PrikaziInformacije()
    {
        Console.WriteLine($"Broj posiljke: {BrojPosiljke} | Naziv primaoca: {ImePrimaoca} | Tezina posiljke: {Tezina} | Status posiljke: {Status}");
    }

}
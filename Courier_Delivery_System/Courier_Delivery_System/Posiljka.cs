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
        Console.WriteLine(ToString());
    }
    public override string ToString()
    {
        return $"Broj posiljke: {BrojPosiljke} | Naziv primaoca: {ImePrimaoca} | Tezina posiljke: {Tezina} | Status posiljke: {Status} | Cjena: {IzracunajCjenu()}";
    }

    public void PromjeniStatus(StatusPosiljke noviStatus)
    {
        bool dozvoljeniPrelaz = (Status == StatusPosiljke.Kreirana && noviStatus == StatusPosiljke.UTransportu) ||
            (Status == StatusPosiljke.UTransportu && noviStatus == StatusPosiljke.Dostavljena) ||
            (Status == StatusPosiljke.Kreirana && noviStatus == StatusPosiljke.Otkazana);

        if(dozvoljeniPrelaz)
        {
            Status = noviStatus;
            Console.WriteLine($"Posiljka broj {BrojPosiljke} promjenila je status u {Status}!");
        }
        else
        {
            Console.WriteLine("Promjena statusa nije dozvoljena!");
        }
    }

}
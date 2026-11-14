using System;

namespace Courier_Delivery_System;

public class EkspresnaPosiljka : Posiljka, IOsigurljivo
{
    private double OsnovnaCijena = 10.0;
    private double CijenaPoKilogramu = 2.0;
    private double CijenaOsiguranja = 0.02;
    private double PrijavljenaVrijednost;

    public EkspresnaPosiljka(int _brojPosiljke, string _imePrimaoca, double _tezina, StatusPosiljke _status) : base(_brojPosiljke, _imePrimaoca, _tezina, _status) { }

    public override double IzracunajCjenu()
    {
        return OsnovnaCijena + (CijenaPoKilogramu*Tezina) + CijenaOsiguranja;
    }

    void IOsigurljivo.Osiguraj(double vrijednost)
    {
        if(vrijednost < 0)
            throw new ArgumentException("Vrijednost mora bit pozitivna!");
        else
            PrijavljenaVrijednost = vrijednost;
        
    }

    double IOsigurljivo.IzracunajOsiguranje()
    {
        return PrijavljenaVrijednost * CijenaOsiguranja;
    }

    public override string ToString()
    {
        return $"[Expresna dostava] {base.ToString()}";
    }
    
}
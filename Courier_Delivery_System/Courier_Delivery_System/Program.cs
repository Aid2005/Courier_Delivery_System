using System;

namespace Courier_Delivery_System;

public class Program
{
    public static void Main()
    {
        int brojac = 0;
        Console.WriteLine("MENI:");
        Console.WriteLine("----------------------------");
        Console.WriteLine("[1]-Kreiraj posiljku");
        Console.WriteLine("----------------------------");
        Console.Write("Izbor: ");
        int meni = int.Parse(Console.ReadLine());

        Posiljka obicna = null;
        EkspresnaPosiljka ekspresna = null;
        Evidencija<Posiljka> evidencija = new Evidencija<Posiljka>();

        switch (meni)
        {
            case 1:
                Console.WriteLine("KREIRANJE POSILJKE");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Opcije: [1-Obicnu posiljku] ili [2-Ekspresna posiljka]");
                Console.Write("Izbor: ");
                int izbor = int.Parse(Console.ReadLine());
                if(izbor == 1)
                {
                    brojac++;
                    Console.WriteLine("Unesite ime primaoca:");
                    string ime = Console.ReadLine();
                    Console.WriteLine("Unesite tezinu posiljke:");
                    double tezina = double.Parse(Console.ReadLine());

                    obicna = new ObicnaPosiljka(brojac,ime,tezina,StatusPosiljke.Kreirana);

                    if(obicna != null)
                    {
                        evidencija.DodajElement(obicna);
                        Console.WriteLine("Pošiljka je poslana!");
                    }
                }
                else if(izbor == 2)
                {
                    brojac++;
                    Console.WriteLine("Unesite ime primaoca:");
                    string ime = Console.ReadLine();
                    Console.WriteLine("Unesite tezinu posiljke:");
                    double tezina = double.Parse(Console.ReadLine());
                    Console.WriteLine("Unesi vrijednost osiguranja: ");
                    double osiguranje = double.Parse(Console.ReadLine());

                    ekspresna = new EkspresnaPosiljka(brojac, ime, tezina, StatusPosiljke.Kreirana);

                    IOsigurljivo osigurljivo = ekspresna;
                    osigurljivo.Osiguraj(osiguranje);

                    if(ekspresna  != null)
                    {
                        evidencija.DodajElement(ekspresna);
                        Console.WriteLine("Pošiljka je poslana!");
                    }
                }
                else
                {
                    Console.WriteLine("Nevažeći unos!");
                }
                break;
            
        }
        
    }
}
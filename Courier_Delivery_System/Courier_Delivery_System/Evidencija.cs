using System;

namespace Courier_Delivery_System;

public class Evidencija<T>
{
    private List<T> list = new List<T>();
    public void DodajElement(T element)
    {
        list.Add(element);
    }

    public bool UkloniElement(T element)
    {
        return list.Remove(element);
    }
    public bool SadrziElement(T element)
    {
        return list.Contains(element); 
    }
    public void PrikaziSve(T element)
    {
        foreach (T item in list)
        {
            Console.WriteLine(item);
        }
    }
}
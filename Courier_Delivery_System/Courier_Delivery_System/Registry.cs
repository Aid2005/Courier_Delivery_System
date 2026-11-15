using System;
using System.Collections.Generic;

namespace Courier_Delivery_System;

// Generic storage acting as an in-memory database
public class Registry<T>
{
    private List<T> items = new List<T>();

    // Add a new item to the registry
    public void AddElement(T element)
    {
        items.Add(element);
    }

    // Remove an existing item from the registry
    public bool RemoveElement(T element)
    {
        return items.Remove(element);
    }

    // Check if an item exists in the registry
    public bool ContainsElement(T element)
    {
        return items.Contains(element);
    }

    // Print all stored items to the console
    public void DisplayAll()
    {
        foreach (T item in items)
        {
            Console.WriteLine(item);
        }
    }

    // Find the first item matching the given condition
    public T Find(Predicate<T> condition)
    {
        return items.Find(condition);
    }
}
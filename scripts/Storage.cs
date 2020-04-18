using Godot;
using System.Collections.Generic;

public class Storage : Node2D
{
    public int size = 50;
    private List<int> storage = new List<int>();

    public bool AddParts()
    {
        if (storage.Count < size)
        {
            storage.Add(0);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AddFood()
    {
        if (storage.Count < size)
        {
            storage.Add(1);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AddFuel()
    {
        if (storage.Count < size)
        {
            storage.Add(1);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveParts()
    {
        if (storage.Count < size)
        {
            storage.Remove(0);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveFood()
    {
        if (storage.Count < size)
        {
            storage.Remove(1);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveFuel()
    {
        if (storage.Count < size)
        {
            storage.Remove(2);
            return true;
        }
        else
        {
            return false;
        }
    }
}

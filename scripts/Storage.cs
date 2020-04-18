using Godot;
using System.Collections.Generic;

public class Storage : Node2D
{
    public int size = 50;
    private List<int> storage = new List<int>();

    public bool AddParts(int amount)
    {
        if (storage.Count + amount < size)
        {
            for (int i = 0; i < amount; i++)
            {
                storage.Add(0);
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AddFood(int amount)
    {
        if (storage.Count + amount < size)
        {
            for (int i = 0; i < amount; i++)
            {
                storage.Add(1);
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool AddFuel(int amount)
    {
        if (storage.Count + amount < size)
        {
            for (int i = 0; i < amount; i++)
            {
                storage.Add(2);
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveParts(int amount)
    {
        if (storage.Contains(0))
        {
            for (int i = 0; i < amount; i++)
            {
                storage.Remove(0);
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveFood(int amount)
    {
        if (storage.Contains(1))
        {
            for (int i = 0; i < amount; i++)
            {
                storage.Remove(1);
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool RemoveFuel(int amount)
    {
        if (storage.Contains(2))
        {
            for (int i = 0; i < amount; i++)
            {
                storage.Remove(2);
            }
            return true;
        }
        else
        {
            return false;
        }
    }
}

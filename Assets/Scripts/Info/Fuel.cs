using UnityEngine;
using UnityEditor;

public class Fuel
{

    public string type;
    public int amount;

    public Fuel(string type)
    {
        this.type = type;
    }

    public bool ChangeAmount(int amount)
    {
        if (this.amount - amount < 0)
            return false;

        this.amount -= amount;
        return true;
    }

}